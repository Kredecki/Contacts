using Contacts.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class AuthController : Controller
    {
        public readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
    }
}
