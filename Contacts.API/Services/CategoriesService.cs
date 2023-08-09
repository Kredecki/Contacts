using Contacts.API.Interfaces;
using Contacts.API.Models;

namespace Contacts.API.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepositroy _categoriesRepositroy;
        public CategoriesService(ICategoriesRepositroy categoriesRepositroy)
        {
            _categoriesRepositroy = categoriesRepositroy;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categoriesRepositroy.GetCategories();
        }

        public async Task<List<Subcategory>> GetBusinessSubCategories()
        {
            return await _categoriesRepositroy.GetBusinessSubCategories();
        }

        public async Task AddNewSubcategory(string subcategoryName)
        {
            Subcategory subcategory = new()
            {
                SubcategoryName = subcategoryName
            };

            await _categoriesRepositroy.subcategoryName(subcategory);
        }

        public async Task<int> GetSubcategoryIdBySubcategoryName(string subcategoryName)
        {
            return await _categoriesRepositroy.GetSubcategoryIdBySubcategoryName(subcategoryName);
        }
    }
}
