using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    internal interface IRecrutation
    {
        public string CheckCandidate(Applicant applicant);
        public void Accept();
        public void Decline();
    }
}
