using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public class Comments
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public Guid SenderId {  get; set; }
        public Guid IssueId {  get; set; }
        public virtual User Sender { get; set; }
        public virtual Issue Issue { get; set; }
    }
}
