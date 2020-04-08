using Railtown.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Railtown.Data.Repository
{
    public class PersonsValidator : IPersonsValidator
    {
        public List<Person> ValidatePersons(IEnumerable<Person> persons)
        {
            var validPersons = new List<Person>();

            foreach (var person in persons)
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
