using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoCL.Models.CustomValidations
{
    public class DateNotGreaterThanCurrent : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var patient = (Patient)validationContext.ObjectInstance;

            if(patient.Birthdate < DateTime.Now)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Date must be less than current date.");
        }
    }
}