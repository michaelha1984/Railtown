using System;
using System.Collections.Generic;
using System.Text;

namespace Railtown.Data.Models
{
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
        public string Phone { get; set; }
    }
}
