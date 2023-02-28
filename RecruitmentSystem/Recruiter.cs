using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    [DataContract]
    public class Recruiter : Person, ICloneable
    {
        int recruited;
        [DataMember]
        public int Recruited { get { return recruited; } set { recruited = value; } }
        public Recruiter(string pesel, string name, string surname, string phoneNumber, string email, enumEducation education)
            : base(pesel, name, surname, phoneNumber, email, education)
        {
            recruited = 0;
        }
        public Recruiter(string pesel, string name, string surname, string phoneNumber, string email, enumEducation education, int recruited)
    : base(pesel, name, surname, phoneNumber, email, education)
        {
            Recruited = recruited;
        }

        public void Recruit()
        {
            Recruited += 1;
        }
        public override string ToString()
        {
            return $"{base.ToString()}; recruited: {Recruited} people";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
