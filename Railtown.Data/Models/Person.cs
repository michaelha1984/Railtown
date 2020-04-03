using System;
using System.Collections.Generic;
using System.Text;

namespace Railtown.Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
