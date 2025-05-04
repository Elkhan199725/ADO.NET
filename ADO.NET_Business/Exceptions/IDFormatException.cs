using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Business.Exceptions
{
    public class IDFormatException : Exception
    {
        public IDFormatException(string message) : base(message) {}
        public IDFormatException(string message, Exception innerException) : base(message, innerException) {}
    }
}
