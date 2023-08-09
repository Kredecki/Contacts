using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepositroy
    {
        private readonly DataContext _db;

        public CategoriesRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<List<Subcategory>> GetBusinessSubCategories()
        {
            return await _db.Subcategories.Where(subcategory => subcategory.SubcategoryId == 1 || subcategory.SubcategoryId == 2).ToListAsync();
        }

        public async Task subcategoryName(Subcategory subcategory)
        {
            _db.Subcategories.Add(subcategory);
            await _db.SaveChangesAsync();
        }

        public async Task<int> GetSubcategoryIdBySubcategoryName(string subcategoryName)
        {
            var subcategory = await _db.Subcategories.FirstOrDefaultAsync(x => x.SubcategoryName == subcategoryName);
            return subcategory.SubcategoryId;
        }

        public async Task<string> GetSubcategoryNameById(int id)
        {
            var subcategory = await _db.Subcategories.FirstOrDefaultAsync(x => x.SubcategoryId == id);
            return subcategory.SubcategoryName;
        }
    }
}
