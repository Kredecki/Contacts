using Contacts.API.Interfaces;
using Contacts.API.Models;

namespace Contacts.API.Services
{
    //Rozdzieliliśmy serwis od kontrolera, aby trzymać w nim logike metod, a w kontrolerze zostawić tylko endpointy. Tutaj jak na cruda przystało logiki jest mało, ale w większych projektach to pomaga.
    public class ContactService : IContactService //Dziedziczymy po interfejsie.
    {
        private readonly IContactRepository _contactRepository;
        //Wstrzykumey repo.
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        //Pobieramy wszystkie kontakty.
        public async Task<List<Contact>> GetContacts()
        {
            //Tutaj rownie dobrze mozna skrocic do: return await _contactRepository.GetContacts();
            //Pobieramy liste kontaktow z repo.
            List<Contact> contacts = await _contactRepository.GetContacts();

            return contacts;
        }

        //Pobieramy kontakty po id.
        public async Task<Contact> GetContactById(int id)
        {
            Contact contact = await _contactRepository.GetContactById(id);
            return contact;
        }

        //Przekazujemy żadanie uysuwania obiektu do repo.
        public async Task RemoveContact(Contact contact)
        {
            await _contactRepository.RemoveContact(contact);
        }

        //Przekazujemy żądanie dodania obiektu do repo.
        public async Task AddContact(Contact contact)
        {
            await _contactRepository.AddContact(contact);
        }

        //Przekazujemy zmodyfikowany obiekt do repo, aby ten go zapisał.
        public async Task UpdateContact(Contact contact)
        {
            await _contactRepository.UpdateContact(contact);
        }
    }
}
