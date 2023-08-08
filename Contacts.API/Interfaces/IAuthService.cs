using Contacts.API.BindingModels;

namespace Contacts.API.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignUp(SignUp model);
        Task<bool> SignIn(SignIn model);
    }
}
