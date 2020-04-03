using Geolocation;
using Railtown.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Railtown.Data.Services
{
    public class GeoService : IGeoService
    {
        public double GetDistanceBetweenPersons(Person person1, Person person2)
        {
            var person1Location = new Coordinate(person1.Address.Geo.Lat, person1.Address.Geo.Long);
            var person2Location = new Coordinate(person2.Address.Geo.Lat, person2.Address.Geo.Long);

            var distance = GeoCalculator.GetDistance(person1Location, person2Location);
            return distance;
        }

        public (Person person1, Person person2) GetPersonsFurthestApart(IEnumerable<Person> persons)
        {
            var distancesBetween = new Dictionary<(Person, Person), double>();

            foreach (var person1 in persons)
            {
                foreach (var person2 in persons)
                {
                    var distance = GetDistanceBetweenPersons(person1, person2);
                    distancesBetween.Add((person1, person2), distance);
                }
            }

            var (personA, personB) = distancesBetween.Aggregate((p1, p2) => p1.Value > p2.Value ? p1 : p2).Key;

            return (personA, personB);
        }
    }
}
