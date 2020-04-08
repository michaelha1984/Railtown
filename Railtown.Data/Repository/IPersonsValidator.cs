using Railtown.Data.Models;
using System.Collections.Generic;

namespace Railtown.Data.Repository
{
    public interface IPersonsValidator
    {
        List<Person> ValidatePersons(IEnumerable<Person> persons);
    }
}