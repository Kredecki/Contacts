using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategories();
    }
}
