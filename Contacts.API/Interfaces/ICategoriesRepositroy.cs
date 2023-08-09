using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    public interface ICategoriesRepositroy
    {
        Task<List<Category>> GetCategories();
        Task<List<Subcategory>> GetBusinessSubCategories();
        Task subcategoryName(Subcategory subcategory);
        Task<int> GetSubcategoryIdBySubcategoryName(string subcategoryName);
    }
}
