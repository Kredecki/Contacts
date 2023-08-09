using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        //Wstrzykujemy serwis do kontrolera.
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        //Endpoint REST API pobierający wszystkie kontakty.
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            List<Contact> contacts = await _contactService.GetContacts();

            return contacts;
        }

        //Endpoint REST API usuwający kontakt.
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RemoveContact(int id)
        {
            //Pierwsze sprawdzamy czy mamy taki kontakt (żeby nie wywaliło nam apki)
            Contact contact = await _contactService.GetContactById(id);

            //jeżeli nie - zwracamy nie znaleziono.
            if (contact == null)
            {
                return NotFound();
            }

            //Jeżeli tak - usuwamy.
            await _contactService.RemoveContact(contact);

            //Zwrotka.
            return Ok();
        }

        //Endpoint REST API dodający kontakt.
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            await _contactService.AddContact(contact);
            return Ok();
        }

        //Endpoint REST API pobierający kontakt po id.
        [HttpGet]
        [Route("[action]")]
        public async Task<Contact> GetContactById(int id)
        {
            return await _contactService.GetContactById(id);
        }

        //Endpoint REST API modyfikujący kontakt.
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            //Szukamy, czy taki istnieje.
            Contact existingContact = await _contactService.GetContactById(contact.ContactId);

            //Jeżeli nie - zwrotka nie znaleziono.
            if (existingContact == null)
            {
                return NotFound();
            }

            //Jeżeli tak to modyfikujemy i zwrotka ok.
            await _contactService.UpdateContact(contact);
            return Ok();
        }
    }
}
