using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Railtown.API.Models
{
    public class PersonsFurthestApart
    {
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public double Distance { get; set; }
    }
}
