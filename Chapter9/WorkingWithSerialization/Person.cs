using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkingWithSerialization
{
    public class Person
    {
        [XmlAttribute("fname")]
        public string FirstName{ get; set; }

        [XmlAttribute("lname")]
        public string LastName { get; set; }

        [XmlAttribute("dbirth")]
        public DateTime DateOfBirth{ get; set; }

        
        public HashSet<Person> Children { get; set; }
        protected decimal Salary{ get; set; }

        public Person(decimal initialSalary){
            Salary = initialSalary;
        }

        public Person(){}

    }
}