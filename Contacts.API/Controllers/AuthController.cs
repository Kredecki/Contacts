using Contacts.API.BindingModels;
using Contacts.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class AuthController : Controller
    {
        public readonly IAuthService _authService;

        //Wstrzykujemy serwis do kontrolera (Wstrzykiwanie zależności).
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //Endpoint REST API służący rejestracji użytkownika.
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp([FromForm] SignUp model)
        {
            //Sprawddzamy czy model się zgadza.
            if (ModelState.IsValid)
            {
                //Rejestrujemy użytkownika w serwisie.
                bool result = await _authService.SignUp(model);
                if (result)
                    //Zwrotka, jeżeli wszystko przeszło poprawnie.
                    return Ok();
            }

            //Zwrotka, jeżeli wystąpiły problemy.
            return BadRequest();
        }

        //Endpoint REST API służący do logowania użytkownika.
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignIn([FromForm] SignIn model)
        {
            //Jeżeli model nie jest prawidłowy wyrzucamy 400.
            if (!ModelState.IsValid)
                return BadRequest("Invalid username or password");

            //Logujemy użytkownika w serwisie.
            bool result = await _authService.SignIn(model);

            //Jeżeli wszystko przeszło poprawnie - zwracamy 200.
            if (result)
                return Ok(new { message = "Login successful" });

            //Jeżeli nie - zwrotka 400.
            return BadRequest("Invalid username or password");
        }

        //Endpoint REST API sprawdzający status zalogowania użytkownika.
        [HttpGet]
        //Znacznik autoryazacji - wpuszcza tylko i wyłącznie wtedy, kiedy w przeglądarce jest ciastko .net identity.
        [Authorize]
        [Route("[action]")]
        public IActionResult IsAuthorized()
        {
            try
            {
                //Jeżeli użytkownik zalogowany.
                return Ok();
            }
            catch (Exception ex)
            {
                //Jeżeli użytkownik nie jest zalogowany.
                return BadRequest(ex);
            }
        }
    }
}
