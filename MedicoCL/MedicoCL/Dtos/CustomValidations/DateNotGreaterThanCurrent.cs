using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MedicoCL.Models;

namespace MedicoCL.Dtos.CustomValidations
{
    public class DateNotGreaterThanCurrent : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var patientDto = (PatientDto)validationContext.ObjectInstance;

            if(patientDto.Birthdate < DateTime.Now)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Date must be less than current date.");
        }
    }
}