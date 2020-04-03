using Geolocation;
using Railtown.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Railtown.Data.Services
{
    public class GeoService
    {
        public double GetDistanceBetweenPersons(Person person1, Person person2)
        {
            var person1Location = new Coordinate(person1.Address.Geo.Lat, person1.Address.Geo.Long);
            var person2Location = new Coordinate(person2.Address.Geo.Lat, person2.Address.Geo.Long);

            var distance = GeoCalculator.GetDistance(person1Location, person2Location);
            return distance;
        }
    }
}
