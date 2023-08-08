using System.ComponentModel.DataAnnotations;

namespace Contacts.API.BindingModels
{
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
