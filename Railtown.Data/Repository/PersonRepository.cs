using Newtonsoft.Json;
using Railtown.Data.Models;
using Railtown.Data.Validation;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Railtown.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPersonValidator _personValidator;

        public PersonRepository(IPersonValidator personValidator)
        {
            _personValidator = personValidator;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            client.UseNewtonsoftJson(new JsonSerializerSettings() 
            {
                MissingMemberHandling = MissingMemberHandling.Error
            });

            var request = new RestRequest("users", Method.GET, DataFormat.Json);
            
            var response = await client.ExecuteAsync<List<Person>>(request);
            
            if (!response.IsSuccessful)
            {
                throw new Exception(); //TODO: Do something else
                // response.StatusCode
            }

            var validPersons = _personValidator.ValidatePersons(response.Data);

            return validPersons;
        }

    }
}
