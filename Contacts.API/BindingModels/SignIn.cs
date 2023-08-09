using System.ComponentModel.DataAnnotations;

namespace Contacts.API.BindingModels
{
    //Model, który służy jedynie do komunikacji FE <=> BE - dokładnie logowania użytkownika.
    public class SignIn
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public SignIn()
        {
            Email = "";
            Password = "";
        }
    }
}
