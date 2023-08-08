using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetContacts();
    }
}
