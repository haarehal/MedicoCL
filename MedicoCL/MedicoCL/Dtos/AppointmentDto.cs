using MedicoCL.Dtos.CustomValidations;
using MedicoCL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoCL.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        [DateGreaterThanCurrent]
        public DateTime DateAndTime { get; set; }

        public int MedicId { get; set; }

        [JsonIgnore]
        public virtual Medic Medic { get; set; }

        public int PatientId { get; set; }

        [JsonIgnore]
        public virtual Patient Patient { get; set; }

        public bool IsUrgent { get; set; }

        [JsonIgnore]
        public virtual TestResult TestResult { get; set; }
    }
}