﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Business.Exceptions
{
    public class UserMissingException : Exception
    {
        public UserMissingException(string message) : base(message) {}
        public UserMissingException(string message, Exception innerException) : base(message, innerException) {}
    }
}
