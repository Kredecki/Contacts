using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContacts();
    }
}
