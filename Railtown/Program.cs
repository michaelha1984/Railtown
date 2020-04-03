using Railtown.Data.Repository;
using Railtown.Data.Services;
using System;
using System.Threading.Tasks;

namespace Railtown
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var personRepository = new PersonRepository();
            var personService = new PersonService(personRepository);
          
            var personsFurthestApart = await personService.GetPersonsFurthestApartAsync();
            Console.WriteLine($"{personsFurthestApart.Person1.Name} " +
                $"and {personsFurthestApart.Person2.Name} live the furthest apart.");

            Console.ReadKey();
        }
    }
}
