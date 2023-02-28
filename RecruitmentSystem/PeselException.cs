using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    internal class PeselException : Exception
    {
        public PeselException() : base() { }
        public PeselException(string message) : base(message) { }
    }
}
