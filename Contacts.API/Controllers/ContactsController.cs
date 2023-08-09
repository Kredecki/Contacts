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
        [Route("[action]")]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            List<Contact> contacts = await _contactService.GetContacts();

            return contacts;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RemoveContact(int id)
        {
            Contact contact = await _contactService.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            await _contactService.RemoveContact(contact);

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            await _contactService.AddContact(contact);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<Contact> GetContactById(int id)
        {
            return await _contactService.GetContactById(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            Contact existingContact = await _contactService.GetContactById(contact.ContactId);

            if (existingContact == null)
            {
                return NotFound();
            }

            await _contactService.UpdateContact(contact);
            return Ok();
        }
    }
}
