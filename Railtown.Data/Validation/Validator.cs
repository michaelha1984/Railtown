﻿using Railtown.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Railtown.Data.Validation
{
    public class Validator<T> where T : new()
    {
        public (bool isValid, List<ValidationResult> results) Validate(T model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, validationContext, results, true);

            return (isValid, results);
        }
    }
}
