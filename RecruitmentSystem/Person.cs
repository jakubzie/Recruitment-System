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

    [DataContract(IsReference = true)] //what is a data contract exactly?
    public abstract class Person : IComparable<Person> //what is an abstract class?
    {
        string pesel;
        string name;
        string surname;
        string phoneNumber;
        string email;
        enumEducation education;

        [DataMember] //what is it?
        public string Pesel
        {
            get { return pesel; }
            init
            {
                if (!Regex.IsMatch(value, @"^\d{11}$")) //regex that checks if PESEL consists of 11 digits
                {
                    throw new PeselException();
                }
                pesel = value;
            }
        }
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
                if (!Regex.IsMatch(value, @"^\d{3}(-)?\d{3}(-)?\d{3}$")) //regex that checks if phone number is given in particular format: 000-000-000
                {
                    throw new PhoneNumberException();
                }
                phoneNumber = value;
            }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set
            {
                if (!Regex.IsMatch(value, @"^([a-z]|\d)*@[a-z]*\.(com|pl)$")) //regex that checks if email adress has particular format: [letters,diggits]@[letters].[com/pl]
                {
                    throw new EmailException();
                }
                email=value;

            }
        }
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

        public int CompareTo(Person? other) //compare method for Person objects
        {
            if (other is null) { return 1; } //if the Person we compare to is null, then return 1.
            int cmpsur = Surname.CompareTo(other.Surname); //CompareTo() method compares two values, if object is bigger than given argument it returns 1, otherwise -1, or 0 if they are equal
            if (cmpsur != 0) { return cmpsur; } //when working with strings, bigger means earlier in the alphabet, so 1 means that our object will be set before the argument
            return Name.CompareTo(other.Name); //if cmpsur == 0 (i.e. surnames are the same) we will check names
            //this method will be automatically used when we execute Sort() method for instances of Person 
        }
    }
}
