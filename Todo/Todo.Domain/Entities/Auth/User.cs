using Microsoft.AspNetCore.Identity;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities.Auth
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string? PhotoPath { get; set; }
        public virtual List<ProgTask> Tasks {  get; set; }
    }
}
