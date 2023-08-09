using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategories();
        Task<List<Subcategory>> GetBusinessSubCategories();
        Task AddNewSubcategory(string subcategoryName);
    }
}
