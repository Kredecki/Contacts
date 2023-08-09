namespace Contacts.API.Models
{
    //Model tabeli "Contact" z bazy.
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; } = string.Empty; //Defaultowo pusty.
        public string Surname { get; set; } = string.Empty; //Defaultowo pusty.
        public string Phone { get; set; } = string.Empty; //Defaultowo pusty.
        public string Email { get; set; } = string.Empty; //Defaultowo pusty.
        public string Password { get; set; } = string.Empty; //Defaultowo pusty.
        public int CategoryId { get; set; } = 0; //Defaultowo 0
        public int SubcategoryId { get; set; } = 0; //Defaultowo 0
        public DateTime BirthDate { get; set; } = DateTime.Now; //Defaultowo data dzisiejsza co do ms
    }
}
