using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            List<Contact> contacts = await _contactService.GetContacts();

            return contacts;
        }
    }
}
