using Contacts.API.BindingModels;
using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Contacts.API.Services
{
    public class AuthService : IAuthService
    {
        public readonly UserManager<User> _userManager;

        public AuthService(UserManager<User> userManager)
        {
            _userManager = userManager;
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
    }
}
