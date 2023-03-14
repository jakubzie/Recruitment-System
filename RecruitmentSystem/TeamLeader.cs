using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    [DataContract]
    public class TeamLeader : Person, ICloneable
    {
        int experience;
        [DataMember]
        public int Experience { get { return experience; } set { experience = value; } }

        public TeamLeader(string pesel, string name, string surname, string phoneNumber, string email, enumEducation education, int experience)
            : base(pesel, name, surname, phoneNumber, email, education)
        {
            Experience = experience;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, years of experience: {Experience}";
        }

        //what is a shallow and deep copy?
        public object Clone() //we can just clone the instance of TeamLeader because it only consists of primitive types
        {
            return MemberwiseClone();
        }
    }
}
