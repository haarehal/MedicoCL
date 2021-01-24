using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MedicoCL.Models.CustomValidations;

namespace MedicoCL.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [DateGreaterThanCurrent]
        [Display(Name = "Date and Time")]
        public DateTime DateAndTime { get; set; }

        [Display(Name = "Medic in Charge")]
        [Required(ErrorMessage = "Medic specialist needs to be selected. If none exist, please create one.")]
        public int MedicId { get; set; }

        [JsonIgnore]
        public virtual Medic Medic { get; set; }

        [Display(Name = "Patient")]
        [Required(ErrorMessage = "Patient needs to be selected. If none exist, please create one.")]
        public int PatientId { get; set; }

        [JsonIgnore]
        public virtual Patient Patient { get; set; }

        [Display(Name = "Urgent")]
        public bool IsUrgent { get; set; }

        [JsonIgnore]
        public virtual TestResult TestResult { get; set; }
    }
}