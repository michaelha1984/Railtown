using System;
using System.Collections.Generic;
using System.Text;

namespace Railtown.API.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
