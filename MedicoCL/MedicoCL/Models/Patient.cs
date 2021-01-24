using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using MedicoCL.Models.CustomValidations;

namespace MedicoCL.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DateNotGreaterThanCurrent]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Genre")]
        public int GenderId { get; set; }

        [JsonIgnore]
        public virtual Gender Gender { get; set; }

        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}