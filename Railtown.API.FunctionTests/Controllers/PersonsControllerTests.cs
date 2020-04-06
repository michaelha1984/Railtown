using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Railtown.API.FunctionTests.Controllers
{
    [TestFixture]
    public class PersonsControllerTests
    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _factory = new WebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [TestCase("/Person")]
        public async Task Get_Person_ReturnSuccessStatus(string url)
        {
            // Arrange
            // Act
            var response = await _client.GetAsync(url);

            //string responseBody = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            
        }
    }
}
