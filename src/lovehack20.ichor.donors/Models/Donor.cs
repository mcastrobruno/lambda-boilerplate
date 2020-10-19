using System;
using System.Collections.Generic;
using System.Text;

namespace Lovehack20.Ichor.Lambda.Models
{
    public class Donor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string EirCode { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
    }
}
