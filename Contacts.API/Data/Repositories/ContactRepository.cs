using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _db;

        public ContactRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Contact>> GetContacts()
        {
            List<Contact> contacts = await _db.Contacts
                .Select(x => new Contact { ContactId = x.ContactId, Name = x.Name, Surname = x.Surname, Phone = x.Phone })
                .ToListAsync();

            return contacts;
        }

        public async Task<Contact> GetContactById(int id)
        {
            Contact contact = await _db.Contacts.SingleOrDefaultAsync(x => x.ContactId == id);
            return contact;
        }

        public async Task RemoveContact(Contact contact)
        {
            _db.Contacts.Remove(contact);
            await _db.SaveChangesAsync();
        }

        public async Task AddContact(Contact contact)
        {
            _db.Contacts.Add(contact);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateContact(Contact contact)
        {
            try
            {
                var existingContact = await _db.Contacts.FindAsync(contact.ContactId);
                if (existingContact != null)
                {
                    _db.Entry(existingContact).State = EntityState.Detached;
                }

                _db.Contacts.Update(contact);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
            }
        }
    }
}
