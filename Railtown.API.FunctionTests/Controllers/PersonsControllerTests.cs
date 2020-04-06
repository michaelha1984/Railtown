using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Railtown.API.FunctionTests.Controllers
{
    [TestFixture]
    public class PersonsControllerTests
    {
        private WebApplicationFactory<Startup> _factory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestCase("/Person")]
        public async Task Get_Person_ReturnSuccessStatus(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            //string responseBody = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            
        }
    }
}
