using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public UserRole UserRole { get; set; }
        public string Description {  get; set; }
    }
}
