using Contacts.API.BindingModels;

namespace Contacts.API.Interfaces
{
    //Interface łączący serwis z kontrolerem.
    public interface IAuthService
    {
        Task<bool> SignUp(SignUp model);
        Task<bool> SignIn(SignIn model);
    }
}
