using Moq;
using NUnit.Framework;
using Railtown.Data.Models;
using Railtown.Data.Repository;
using Railtown.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Railtown.Data.UnitTest.Service
{
    [TestFixture]
    public class PersonServiceTests
    {
        public PersonServiceTests()
        {

        }

        [Test]
        public async Task GetPersonsFurthestApartAsync_OnlyOnePerson_ReturnsPersonAsync()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person()
                {
                    Name = "P1",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -37.3159,
                            Long = 81.1496
                        }
                    }
                }
            };

            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(x => x.GetAllPersonsAsync()).ReturnsAsync(persons);

            var personService = new PersonService(personRepository.Object);

            // Act
            var personsFurthestApart = await personService.GetPersonsFurthestApartAsync();

            // Assert
            Assert.AreEqual(personsFurthestApart.Person1.Name, personsFurthestApart.Person2.Name);
        }

        [Test]
        public async Task GetPersonsFurthestApartAsync_TwoSameGeo_ReturnsBothPersonsAsync()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person()
                {
                    Name = "P1",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -37.3159,
                            Long = 81.1496
                        }
                    }
                },
                new Person()
                {
                    Name = "P2",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -37.3159,
                            Long = 81.1496
                        }
                    }
                }
            };

            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(x => x.GetAllPersonsAsync()).ReturnsAsync(persons);

            var personService = new PersonService(personRepository.Object);

            // Act
            var personsFurthestApart = await personService.GetPersonsFurthestApartAsync();

            // Assert
            Assert.AreNotEqual(personsFurthestApart.Person1.Name, personsFurthestApart.Person2.Name);
            Assert.AreEqual(personsFurthestApart.Person1.Address.Geo.Lat, personsFurthestApart.Person2.Address.Geo.Lat);
            Assert.AreEqual(personsFurthestApart.Person1.Address.Geo.Long, personsFurthestApart.Person2.Address.Geo.Long);
        }

        [Test]
        public async Task GetPersonsFurthestApartAsync_TwoDifferentGeo_ReturnsBothPersonsAsync()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person()
                {
                    Name = "P1",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -37.3159,
                            Long = 81.1496
                        }
                    }
                },
                new Person()
                {
                    Name = "P2",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -43.9509,
                            Long = -34.4618
                        }
                    }
                }
            };

            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(x => x.GetAllPersonsAsync()).ReturnsAsync(persons);

            var personService = new PersonService(personRepository.Object);

            // Act
            var personsFurthestApart = await personService.GetPersonsFurthestApartAsync();

            // Assert
            Assert.AreNotEqual(personsFurthestApart.Person1.Name, personsFurthestApart.Person2.Name);
        }

        [Test]
        public async Task GetPersonsFurthestApartAsync_NDifferentGeoLong_ReturnsFurthestLongPersonsAsync()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person()
                {
                    Name = "P1",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -37.3159,
                            Long = 90
                        }
                    }
                },
                new Person()
                {
                    Name = "P2",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -43.9509,
                            Long = -34.4618
                        }
                    }
                },
                new Person()
                {
                    Name = "P3",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -37.3159,
                            Long = -90
                        }
                    }
                }
            };

            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(x => x.GetAllPersonsAsync()).ReturnsAsync(persons);

            var personService = new PersonService(personRepository.Object);

            // Act
            var personsFurthestApart = await personService.GetPersonsFurthestApartAsync();

            // Assert
            Assert.AreNotEqual(personsFurthestApart.Person1.Name, personsFurthestApart.Person2.Name);

            // The return can be random
            Assert.AreNotEqual("P2", personsFurthestApart.Person1.Name); // P1 or P3
            Assert.AreNotEqual("P2", personsFurthestApart.Person2.Name); // P1 or P3
        }

        [Test]
        public async Task GetPersonsFurthestApartAsync_NDifferentGeoLat_ReturnsFurthestLatPersonsAsync()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person()
                {
                    Name = "P1",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = 90,
                            Long = 81.1496
                        }
                    }
                },
                new Person()
                {
                    Name = "P2",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -43.9509,
                            Long = -34.4618
                        }
                    }
                },
                new Person()
                {
                    Name = "P3",
                    Address = new Address()
                    {
                        Geo = new Geo() {
                            Lat = -90,
                            Long = 81.1496
                        }
                    }
                }
            };

            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(x => x.GetAllPersonsAsync()).ReturnsAsync(persons);

            var personService = new PersonService(personRepository.Object);

            // Act
            var personsFurthestApart = await personService.GetPersonsFurthestApartAsync();

            // Assert
            Assert.AreNotEqual(personsFurthestApart.Person1.Name, personsFurthestApart.Person2.Name);

            // The return can be random
            Assert.AreNotEqual("P2", personsFurthestApart.Person1.Name); // P1 or P3
            Assert.AreNotEqual("P2", personsFurthestApart.Person2.Name); // P1 or P3
        }

        [Test]
        public async Task GetPersonsFurthestApartAsync_NoPersons_ReturnsNull()
        {
            // Arrange
            var persons = new List<Person>();

            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(x => x.GetAllPersonsAsync()).ReturnsAsync(persons);

            var personService = new PersonService(personRepository.Object);

            // Act
            var personsFurthestApart = await personService.GetPersonsFurthestApartAsync();

            // Assert
            Assert.AreEqual(null, personsFurthestApart.Person1);
            Assert.AreEqual(null, personsFurthestApart.Person2);
        }
    }
}
