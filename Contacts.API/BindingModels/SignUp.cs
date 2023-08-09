using System.ComponentModel.DataAnnotations;

namespace Contacts.API.BindingModels
{
    //Model, który służy jedynie do komunikacji FE <=> BE - dokładnie rejestracji użytkownika.
    public class SignUp
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Repassword { get; set; }

        public SignUp()
        {
            Email = "";
            Password = "";
            Repassword = "";
        }
    }
}
