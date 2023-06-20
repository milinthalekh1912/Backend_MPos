using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;
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

        public async Task<List<sku>> getAllSkuAsync()
        {
            var all_sku = await _context.sku.AsNoTracking().Where(e => true).ToListAsync();
            return all_sku;
        }
        public async Task<List<SkuRecommendResult>> GetSkuRecommend(string supplier_id)
        {
            //var skus = await _context.sku.Join(_context.pricetier, sku => sku.sku_id, pricetier => pricetier.sku_id,
            //        (sku, pricetier) => new { SKU = sku, PriceTier = pricetier })
            //        .Where(x => x.SKU.supplier_id == supplier_id)
            //        .ToListAsync();

            var skus = await _context.sku.AsNoTracking().Where(e => e.supplier_id == supplier_id).ToListAsync();

            List<SkuRecommendResult> result = new List<SkuRecommendResult>();

            foreach (var SKU in skus)
            {
                SkuRecommendResult obj = new SkuRecommendResult();
                obj.title = SKU.title;
                obj.aliasTitle = SKU.alias_title;
                obj.sku = SKU.sku_id;
                obj.barcode = SKU.barcode;
                obj.imageUrl = SKU.image_url;
                obj.categoryId = SKU.category_id;
                result.Add(obj);
            }

            return result;
        }


        public async Task<List<SkuByKeywordResult>> GetSkuByKeyword(string? keyword)
        {
            var query = _context.sku.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.alias_title.Contains(keyword) || x.title.Contains(keyword) || x.barcode.Contains(keyword));
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
            var productinfo = await _context.sku.AsNoTracking().Where(x => x.category_id == categoryId && x.supplier_id == supplierId).ToListAsync();
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




