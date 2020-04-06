using Geolocation;
using Railtown.Data.Models;
using Railtown.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railtown.Data.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        private double GetDistanceBetweenPersons(Person person1, Person person2)
        {
            var person1Location = new Coordinate(person1.Address.Geo.Lat, person1.Address.Geo.Long);
            var person2Location = new Coordinate(person2.Address.Geo.Lat, person2.Address.Geo.Long);

            var distance = GeoCalculator.GetDistance(person1Location, person2Location);
            return distance;
        }

        public async Task<PersonsFurthestApart> GetPersonsFurthestApartAsync()
        {
            var personsApart = new PersonsFurthestApart();
                       
            var persons = await personRepository.GetAllPersonsAsync();

            if (persons.Count == 1)
            {
                personsApart.Person1 = persons[0];
                personsApart.Person2 = persons[0];
                return personsApart;
            }
            else if (persons.Count >= 2)
            {
                var distancesBetween = new Dictionary<(Person, Person), double>();

                var queue = new Queue<Person>(persons);

                while (queue.Count > 0)
                {
                    var person1 = queue.Dequeue();

                    foreach (var person2 in queue)
                    {
                        var distance = GetDistanceBetweenPersons(person1, person2);
                        distancesBetween.Add((person1, person2), distance);
                    }
                }

                var keyValuePair = distancesBetween.Aggregate((db1, db2) => db1.Value > db2.Value ? db1 : db2);

                personsApart.Person1 = keyValuePair.Key.Item1;
                personsApart.Person2 = keyValuePair.Key.Item2;
                personsApart.Distance = keyValuePair.Value;
                return personsApart;
            }

            return personsApart;
        }
    }
}
