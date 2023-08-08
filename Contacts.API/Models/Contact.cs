namespace Contacts.API.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int CategoryId { get; set; } = 0;
        public int SubcategoryId { get; set; } = 0;
        public DateTime BirthDate { get; set; } = DateTime.Now;
    }
}
