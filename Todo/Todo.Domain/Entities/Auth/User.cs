using Microsoft.AspNetCore.Identity;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public UserRole UserRole { get; set; }
        public string Description { get; set; }
    }
}
