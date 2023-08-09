using Contacts.API.Interfaces;
using Contacts.API.Models;

namespace Contacts.API.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<Contact>> GetContacts()
        {
            List<Contact> contacts = await _contactRepository.GetContacts();

            return contacts;
        }

        public async Task<Contact> GetContactById(int id)
        {
            Contact contact = await _contactRepository.GetContactById(id);
            return contact;
        }

        public async Task RemoveContact(Contact contact)
        {
            await _contactRepository.RemoveContact(contact);
        }

        public async Task AddContact(Contact contact)
        {
            await _contactRepository.AddContact(contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            await _contactRepository.UpdateContact(contact);
        }
    }
}
