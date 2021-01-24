using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoCL.Models.CustomValidations
{
    public class AvailableMedicInDb : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var appointment = (Appointment)validationContext.ObjectInstance;

            if (appointment.DateAndTime >= DateTime.Now)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Date and time must be greater than or equal to current date and time.");
        }
    }
}