using Contacts.API.BindingModels;
using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Contacts.API.Services
{
    public class AuthService : IAuthService
    {
        public readonly UserManager<User> _userManager;
        public readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> SignUp(SignUp model)
        {
            try
            {
                User user = new() { UserName = model.Email, Email = model.Email };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SignIn(SignIn model)
        {
            try
            {
                User user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                    return false;

                if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }
    }
}
