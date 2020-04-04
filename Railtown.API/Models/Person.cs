using System;
using System.Collections.Generic;
using System.Text;

namespace Railtown.API.Models
{
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string CompanyName { get; set; } 
        public string Phone { get; set; }
    }
}
