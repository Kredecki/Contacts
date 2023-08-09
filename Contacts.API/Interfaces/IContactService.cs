using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetContacts();
        Task<Contact> GetContactById(int id);
        Task RemoveContact(Contact contact);
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
    }
}
