using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MedicoCL.Models;

namespace MedicoCL.Dtos.CustomValidations
{
    public class DateGreaterThanCurrent : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var appointmentDto = (AppointmentDto)validationContext.ObjectInstance;

            if (appointmentDto.DateAndTime >= DateTime.Now)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Date and time must be greater than or equal to current date and time.");
        }
    }
}