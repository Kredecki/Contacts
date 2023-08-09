namespace Contacts.API.Models
{
    //Model tabeli "Category" z bazy.
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty; //Defaultowo pusty.
    }
}
