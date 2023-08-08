using Contacts.API.BindingModels;
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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp([FromForm] SignUp model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _authService.SignUp(model);
                if (result)
                    return Ok();
            }

            return BadRequest();
        }
    }
}
