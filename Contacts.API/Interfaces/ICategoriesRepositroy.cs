using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    public interface ICategoriesRepositroy
    {
        Task<List<Category>> GetCategories();
    }
}
