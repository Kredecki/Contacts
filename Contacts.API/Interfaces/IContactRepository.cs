using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContacts();
        Task<Contact> GetContactById(int id);
        Task RemoveContact(Contact contact);
    }
}
