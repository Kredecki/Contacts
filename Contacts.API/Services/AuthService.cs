using Contacts.API.BindingModels;
using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Contacts.API.Services
{
    //Rozdzieliliśmy serwis od kontrolera, aby trzymać w nim logike metod, a w kontrolerze zostawić tylko endpointy. Tutaj jak na cruda przystało logiki jest mało, ale w większych projektach to pomaga.
    public class AuthService : IAuthService //Dziedziczymy po interfejsie.
    {
        public readonly UserManager<User> _userManager;
        public readonly SignInManager<User> _signInManager;
        
        //Wstrzykujemy klasy z biblioteki .net identity.
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Logika rejestracji użytkownika.
        public async Task<bool> SignUp(SignUp model)
        {
            //Jeżeli coś się nie uda to po prostu zwracamy false - tak jest bezpiecznie.
            try
            {
                //Tworzymy nowy obiekt użyszkodnika.
                User user = new() { UserName = model.Email, Email = model.Email };
                //Tworzymy nowego użytkownika.
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                //Jeżeli się uda to zwracamy true do kontrolera, a ten zwróci okejke.
                if (result.Succeeded)
                    return true;
                else //Jeżeli nie to false, a ten zwróci 400.
                    return false;
            }
            catch(Exception ex) //Wyłapujemy co się stało.
            {
                //tutaj można zwrócić jeszcze jakiś komunikat do logów np. loggerem lub jakąś swoją metodą.
                return false;
            }
        }

        //Logika logowania użytkownika.
        public async Task<bool> SignIn(SignIn model)
        {
            //Jeżeli się nie uda to false.
            try
            {
                //Szukamy czy taki użytkownik istnieje
                User user = await _userManager.FindByEmailAsync(model.Email);

                //Jeżeli nie to zwracamy false do kontrolera, a ten zwróci 400.
                if (user == null)
                    return false;

                //Jeżeli tak to sprawdzamy czy hasło jest poprawne. Jeżeli jest to true => kontroler => ok => status 200.
                if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    return true;
            }
            catch (Exception ex)
            {
                //Można wyłapać błąd i z nim dalej działać.
                return false;
            }

            //Jeżeli hasło nie jest poprawne to false => kontroler => BadRequest => 400.
            return false;
        }
    }
}
