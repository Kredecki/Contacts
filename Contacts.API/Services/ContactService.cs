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
    }
}
