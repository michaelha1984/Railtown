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
        }
    }
}
