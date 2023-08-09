namespace Contacts.API.Models
{
    //Model tabeli "Subcategory" z bazy.
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; } = string.Empty; //Defaultowo pusty.
    }
}
