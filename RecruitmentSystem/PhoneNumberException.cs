using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    internal class PhoneNumberException : Exception
    {
        public PhoneNumberException() : base() { }
        public PhoneNumberException(string message) : base(message) { }
    }
}
