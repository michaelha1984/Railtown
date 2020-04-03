using Railtown.Data.Models;
using System.Collections.Generic;

namespace Railtown.Data.Services
{
    public interface IGeoService
    {
        double GetDistanceBetweenPersons(Person person1, Person person2);
        (Person person1, Person person2) GetPersonsFurthestApart(IEnumerable<Person> persons);
    }
}