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
                .Select(x => new Contact { Name = x.Name, Surname = x.Surname, Phone = x.Phone })
                .ToListAsync();

            return contacts;
        }
    }
}
