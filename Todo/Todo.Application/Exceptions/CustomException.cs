using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Exceptions
{
    public class CustomException : Exception
    {
        public int StatuCode { get; set; }
        public CustomException(int code, string message) : base(message)
        {
            StatuCode = code;
        }
    }
}
