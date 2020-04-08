using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Railtown.Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        public Address Address { get; set; }
        public Company Company { get; set; } // we could flatten this mappers if it was required
        public string Phone { get; set; }
        public string Website { get; set; }
    }
}
