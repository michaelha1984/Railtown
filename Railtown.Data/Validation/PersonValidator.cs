using Railtown.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Railtown.Data.Validation
{
    public class PersonValidator : IPersonValidator
    {
        private readonly Validator<Person> _personsValidator;

        public PersonValidator(Validator<Person> personsValidator)
        {
            _personsValidator = personsValidator;
        }

        public List<Person> ValidatePersons(IEnumerable<Person> persons)
        {
            var validPersons = new List<Person>();

            foreach (var person in persons)
            {
                var (isValid, results) = _personsValidator.Validate(person);

                if (!isValid)
                {
                    //TODO: Do something with bad data                   
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
