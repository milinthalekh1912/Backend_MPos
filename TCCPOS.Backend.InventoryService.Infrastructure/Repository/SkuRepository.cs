using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuWithPriceTierByPriceTierID;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductByCat;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductRecommend;
using TCCPOS.Backend.InventoryService.Application.Feature.Supplier.Query.GetSupplier;
using TCCPOS.Backend.InventoryService.Entities;


namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class SkuRepository : ISkuRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public SkuRepository(InventoryContext context, DateTime _dtnow)
        {
            _context = context;
            _dtnow = DateTime.Now;
        }

        public async Task SaveChangeAsyncWithCommit()
        {
            if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                _context.Database.SetCommandTimeout(120);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<sku>> getAllSkuAsync(string supplierId)
        {
            var all_sku = await _context.sku.AsNoTracking().Where(e => e.supplier_id == supplierId && e.IsActive == true).ToListAsync();
            return all_sku;
        }
        public async Task<List<SkuRecommendResult>> GetSkuRecommend(string supplier_id,string merchantId)
        {
            //var skus = await _context.sku.Join(_context.pricetier, sku => sku.sku_id, pricetier => pricetier.sku_id,
            //        (sku, pricetier) => new { SKU = sku, PriceTier = pricetier })
            //        .Where(x => x.SKU.supplierId == supplierId)
            //        .ToListAsync();

            var query = from order in _context.order
                        where order.supplier_id == supplier_id && order.merchant_id == merchantId
                        join orderItem in (
                            from sku in _context.sku
                            where sku.supplier_id == supplier_id && sku.IsActive == true
                            join oi in _context.orderdetail on sku.sku_id equals oi.sku_id
                            select new { SKU = sku, OrderItem = oi }
                        ) on order.order_id equals orderItem.OrderItem.order_id
                        select new { Order = order, SKU = orderItem.SKU, OrderItem = orderItem.OrderItem };

            var skus = await _context.sku.AsNoTracking().Where(e => e.supplier_id == supplier_id && e.IsActive == true).ToListAsync();

            List<SkuRecommendResult> result = new List<SkuRecommendResult>();

            foreach (var item in query)
            {
                SkuRecommendResult obj = new SkuRecommendResult();
                obj.title = item.SKU.title;
                obj.aliasTitle = item.SKU.alias_title;
                obj.sku = item.SKU.sku_id;
                obj.barcode = item.SKU.barcode;
                obj.imageUrl = item.SKU.image_url;
                obj.categoryId = item.SKU.category_id;
                result.Add(obj);
            }

            return result;
        }

        public async Task<List<sku>> GetAllSkuBySupplierId(string supplier_id)
        {
            var query = await _context.sku.Where(x => x.supplier_id == supplier_id && x.IsActive == true).ToListAsync();
            if (query == null && query.Count == 0) throw InventoryServiceException.IE016;
            return query;
        }
        //GetAllSkuWithPriceTierByPriceTierIDResult
        public async Task<GetAllSkuWithPriceTierByPriceTierIDResult> GetAllSkuWithPriceTierByPriceTierId(string supplier_id, string price_tier_id)
        {
            var sku_unit = from sku in _context.sku
                           where sku.supplier_id == supplier_id && sku.IsActive == true
                           join unit in _context.unit
                           on sku.unit_id equals unit.unit_id
                           select new
                           {
                               SKU = sku,
                               Unit = unit,
                           };
            var query = from skuIsUnit in sku_unit
                         join pricetier in _context.pricetier
                         on skuIsUnit.SKU.sku_id equals pricetier.sku_id
                         select new
                         {
                             SKU = skuIsUnit.SKU,
                             UNIT = skuIsUnit.Unit,
                             PRICETIER = pricetier
                         };
           /* var query = from sku in _context.sku
                        where sku.supplier_id == supplier_id
                        join pricetier in _context.pricetier
                        on sku.sku_id equals pricetier.sku_id
                        select new
                        {
                            SKU = sku,
                            PriceTier = pricetier
                        };*/
            var search =  await query.AsNoTracking().Where(e => e.PRICETIER.price_tier_group_id == price_tier_id).ToListAsync();
            var res = new GetAllSkuWithPriceTierByPriceTierIDResult();

            foreach(var sku_with_price in search)
            {
                GetAllSkuWithPriceTierByPriceTierIDItemResult item = new GetAllSkuWithPriceTierByPriceTierIDItemResult();
                item.sku = sku_with_price.SKU.sku_id;
                item.barcode = sku_with_price.SKU.barcode;
                item.title = sku_with_price.SKU.title;
                item.aliasTitle = sku_with_price.SKU.alias_title;
                item.imageUrl = sku_with_price.SKU.image_url;
                item.price = sku_with_price.PRICETIER.price;
                item.categoryId = sku_with_price.SKU.category_id;
                item.unitTitle = sku_with_price.UNIT.unit_name;
                res.item.Add(item);
            }

            return res;
        }


        public async Task<List<SkuByKeywordResult>> GetSkuByKeyword(string? keyword)
        {
            var query = _context.sku.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => (x.alias_title.Contains(keyword) || x.title.Contains(keyword) || x.barcode.Contains(keyword)) && x.IsActive == true);
            }

            var products = await query.ToListAsync();

            var result = new List<SkuByKeywordResult>();

            foreach (var product in products)
            {
                SkuByKeywordResult obj = new SkuByKeywordResult();

                obj.title = product.title;
                obj.aliasTitle = product.alias_title;
                obj.sku = product.sku_id;
                obj.barcode = product.barcode;
                obj.imageUrl = product.image_url;
                obj.categoryId = product.category_id;
                result.Add(obj);
            }

            return result;
        }

        public async Task<List<GetProductByCatResult>> GetSkuBycateID(string categoryId, string supplierId, string shopId)
        {
            var productinfo = await _context.sku.AsNoTracking().Where(x => x.category_id == categoryId && x.supplier_id == supplierId && x.IsActive == true).ToListAsync();
            List<GetProductByCatResult> results = new List<GetProductByCatResult>();
            if (productinfo == null || !productinfo.Any())
            {
                throw InventoryServiceException.IE001;
            }

            foreach (var item in productinfo)
            {
                GetProductByCatResult obj = new GetProductByCatResult();
                obj.title = item.title;
                obj.aliasTitle = item.alias_title;
                obj.sku = item.sku_id;
                obj.barcode = item.barcode;
                obj.imageUrl = item.image_url;
                obj.categoryId = item.category_id;
                results.Add(obj);
            }
            return results;
        }

    }
}




