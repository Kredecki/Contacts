using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
