using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    //Interface łączący serwis z kontrolerem.
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategories();
        Task<List<Subcategory>> GetBusinessSubCategories();
        Task AddNewSubcategory(string subcategoryName);
        Task<int> GetSubcategoryIdBySubcategoryName(string subcategoryName);
        Task<string> GetSubcategoryNameById(int id);
    }
}
