using Newtonsoft.Json;
using Railtown.Data.Models;
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
                throw new Exception(); // Do something else
                // response.StatusCode
            }

            var validPersons = new List<Person>();

            foreach (var person in response.Data)
            {
                var results = new List<ValidationResult>();
                var validationContext = new ValidationContext(person);
                var isValid = Validator.TryValidateObject(person, validationContext, results, true);

                if (!isValid)
                {
                    // Do something with bad data                   
                }
                else
                {
                    validPersons.Add(person);
                }
            }

            return validPersons;
        }
    }
}
