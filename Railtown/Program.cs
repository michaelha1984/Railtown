using Railtown.Data.Models;
using Railtown.Data.Repository;
using Railtown.Data.Services;
using Railtown.Data.Validation;
using System;
using System.Threading.Tasks;

namespace Railtown
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var validator = new Validator<Person>();
            var repository = new PersonRepository(validator);
            var personService = new PersonService(repository);
          
            var personsFurthestApart = await personService.GetPersonsFurthestApartAsync();
            Console.WriteLine($"{personsFurthestApart.Person1.Name} " +
                $"and {personsFurthestApart.Person2.Name} live the furthest apart.");

            Console.ReadKey();
        }
    }
}
