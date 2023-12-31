﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory;
using TCCPOS.Backend.InventoryService.Entities;


namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public CategoriesRepository(InventoryContext context, DateTime _dtnow)
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



        public async Task<List<category>> GetCategoryBySupplierIdAsync(string supplier_id)
        {
            var categories = await _context.category.Where(e => e.supplier_id == supplier_id).ToListAsync();
            return categories;
        }

        public async Task<List<category>> GetCategoryBySupplierIdForLine(string supplier_id)
        {
            var categories = await _context.category.Where(e => e.supplier_id == supplier_id).ToListAsync();
           
            return categories;


        }



    }
}




