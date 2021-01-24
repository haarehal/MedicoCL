using MedicoCL.Dtos.CustomValidations;
using MedicoCL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MedicoCL.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DateNotGreaterThanCurrent]
        public DateTime Birthdate { get; set; }

        public int GenderId { get; set; }

        [JsonIgnore]
        public virtual GenderDto Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}