﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Railtown.Data.Models
{
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; } // we could flatten this mappers if it was required
        public string Phone { get; set; }
    }
}
