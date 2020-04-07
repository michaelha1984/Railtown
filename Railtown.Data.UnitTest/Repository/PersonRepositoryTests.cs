using NUnit.Framework;
using Railtown.Data.Repository;
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
            var repository = new PersonRepository();

            // Act
            var persons = await repository.GetAllPersonsAsync();

            // Assert
            Assert.True(persons.Any(p => p.Address.Geo.Lat != 0));
            Assert.True(persons.Any(p => p.Address.Geo.Lng != 0));
        }
    }
}
