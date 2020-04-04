using Railtown.Data.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Railtown.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public async Task<List<Person>> GetAllPersonsAsync()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");

            var request = new RestRequest("users", DataFormat.Json);
            
            var response = await client.GetAsync<List<Person>>(request);
            return response;
        }
    }
}
