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
            var persons = await personRepository.GetAllPersonsAsync();

            var geoService = new GeoService();
            var distance = geoService.GetDistanceBetweenPersons(persons[0], persons[1]);

            Console.WriteLine(distance);

            var (person1, person2) = geoService.GetPersonsFurthestApart(persons);
            Console.WriteLine($"{person1.Name} and {person2.Name} live the furthest apart.");
            Console.ReadKey();
        }
    }
}
