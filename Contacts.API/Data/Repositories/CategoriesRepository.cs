using Contacts.API.Interfaces;
using Contacts.API.Models;
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
    }
}
