using Contacts.API.Models;

namespace Contacts.API.Interfaces
{
    //Interface łączący repo z serwisem.
    public interface IContactRepository
    {
        Task<List<Contact>> GetContacts();
        Task<Contact> GetContactById(int id);
        Task RemoveContact(Contact contact);
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
    }
}
