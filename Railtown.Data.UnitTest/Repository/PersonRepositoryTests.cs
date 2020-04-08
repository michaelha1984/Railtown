using NUnit.Framework;
using Railtown.Data.Models;
using Railtown.Data.Repository;
using Railtown.Data.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railtown.Data.UnitTest.Repository
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        [Test]
        public async Task GetAllPersonsAsync()
        {
            // Arrange
            var validator = new Validator<Person>();
            var repository = new PersonRepository(validator);

            // Act
            var persons = await repository.GetAllPersonsAsync();

            // Assert
            Assert.True(persons.Any(p => p.Address.Geo.Lat != 0));
            Assert.True(persons.Any(p => p.Address.Geo.Lng != 0));
        }
    }
}
