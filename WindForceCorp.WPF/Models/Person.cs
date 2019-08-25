using System;
using System.Collections.Generic;
using System.Text;

namespace WindForceCorp.WPF.Models
{
    public class Person
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string EmailAddress { get; set; }
    }
}
