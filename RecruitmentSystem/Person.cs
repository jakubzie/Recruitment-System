using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    public enum enumEducation { primary, secondary, higher }

    [DataContract(IsReference = true)]
    public abstract class Person : IComparable<Person>
    {
        string pesel;
        string name;
        string surname;
        string phoneNumber;
        string email;
        enumEducation education;

        [DataMember]
        public string Pesel
        {
            get { return pesel; }
            init
            {
                if (!Regex.IsMatch(value, @"^\d{11}$"))
                {
                    throw new PeselException();
                }
                pesel = value;
            }
        } //sprawdzanie czy spełnia warunki przy setcie / initcie 
        [DataMember]
        public string Name { get { return name; } set { name = value; } }
        [DataMember]
        public string Surname { get { return surname; } set { surname = value; } }
        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (Regex.IsMatch(value, @"^\d{3}(-)?\d{3}(-)?\d{3}$"))
                {
                    phoneNumber = value;
                }
                else { throw new PhoneNumberException(); }
            }
        } //sprawdzanie
        [DataMember]
        public string Email
        {
            get { return email; }
            set
            {
                if (Regex.IsMatch(value, @"^*(gmail)?\.com$")) //dokończyć
                {
                    email = value;
                }
                else { throw new EmailException(); }

            }
        } //sprawdzanie
        [DataMember]
        public enumEducation Education { get { return education; } set { education = value; } }

        public Person(string pesel, string name, string surname, string phoneNumber, string email, enumEducation education)
        {
            Pesel = pesel;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Education = education;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, PESEL: {Pesel}, {Email}; {PhoneNumber}";
        }

        public int CompareTo(Person? other)
        {
            if (other is null) { return 1; }
            int cmpsur = Surname.CompareTo(other.Surname);
            if (cmpsur != 0) { return cmpsur; }
            return Name.CompareTo(other.Name);
        }
        //rnuiefhreofheofheoh
    }
}
