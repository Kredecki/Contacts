using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data.Repositories
{
    //Rozdzielamy repozytorium do serwisu, aby zostawić w nim samą logikę. W repo łączymy się z bazą danych, na której wykonujemy operacje.
    public class ContactRepository : IContactRepository //Dziedziczymy po interface
    {
        private readonly DataContext _db;
        //Wstrzykujemy kontekst bazy danych do repo.
        public ContactRepository(DataContext db)
        {
            _db = db;
        }

        //Pobieramy wszystkie kontakty.
        public async Task<List<Contact>> GetContacts()
        {
            List<Contact> contacts = await _db.Contacts
                .Select(x => new Contact { ContactId = x.ContactId, Name = x.Name, Surname = x.Surname, Phone = x.Phone }) //Deifniujemy pola, które chcemy pobrać. Jest to ważne, żeby nie pobierać niepotrzebnych danych.
                .ToListAsync(); //DOdajemy do listy.

            return contacts;
        }

        //Pobieramy kontakt po id.
        public async Task<Contact> GetContactById(int id)
        {
            Contact contact = await _db.Contacts.SingleOrDefaultAsync(x => x.ContactId == id); //Id jest unikalne. Zawsze to będzie 1 kontakt.
            return contact;
        }

        //usuwamy kontakt, w parametrze przyjmujemy obiekt.
        public async Task RemoveContact(Contact contact)
        {
            _db.Contacts.Remove(contact); //usuwanie.
            await _db.SaveChangesAsync(); //zapisywanie zmian.
        }

        //Dodajemy kontakt, w parametrze przyjmujemy obiekt.
        public async Task AddContact(Contact contact)
        {
            _db.Contacts.Add(contact); //Dodawanie.
            await _db.SaveChangesAsync(); //zapisywanie zmian w bazie.
        }

        //Modyfikujemy kontakt, w parametrze przyjmujemy obiekt.
        public async Task UpdateContact(Contact contact)
        {
            //Zanim go zmodyfikujemy musimy zrobić detach z obiektu id
            var existingContact = await _db.Contacts.FindAsync(contact.ContactId);
            if (existingContact != null)
            {
                _db.Entry(existingContact).State = EntityState.Detached;
            }

            _db.Contacts.Update(contact); //modyfikacja
            await _db.SaveChangesAsync(); //zapis
        }
    }
}
