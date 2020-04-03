﻿using Geolocation;
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

                foreach (var person1 in persons)
                {
                    foreach (var person2 in persons)
                    {
                        var distance = GetDistanceBetweenPersons(person1, person2);
                        distancesBetween.Add((person1, person2), distance);
                    }
                }

                var (personA, personB) = distancesBetween.Aggregate((p1, p2) => p1.Value > p2.Value ? p1 : p2).Key;

                personsApart.Person1 = personA;
                personsApart.Person2 = personB;
                return personsApart;
            }

            return personsApart;
        }
    }
}
