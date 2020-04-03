using Railtown.Data.Repository;
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

            Console.WriteLine(persons.Count);
        }
    }
}
