using Railtown.Data.Models;
using System.Collections.Generic;

namespace Railtown.Data.Validation
{
    public interface IPersonValidator
    {
        List<Person> ValidatePersons(IEnumerable<Person> persons);
    }
}