using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    internal class EmailException : Exception
    {
        public EmailException() : base() { }
        public EmailException(string message) : base(message) { }
    }
}
