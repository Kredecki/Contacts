using Microsoft.AspNetCore.Identity;

namespace Contacts.API.Models
{
    //Model Usera, który dziedziczy po IdentityUser z biblioteki .Net Identity. Określamy, że jego id jest Globally Unique Identifier (guid) Tabela: AspNetUsers
    public class User : IdentityUser<Guid>
    {
    }
}
