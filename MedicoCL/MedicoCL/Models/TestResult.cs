using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MedicoCL.Models;

namespace MedicoCL.Models
{
    public class TestResult
    {
        [ForeignKey("Appointment")]
        public int TestResultId { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int AppointmentId { get; set; }

        [JsonIgnore]
        public virtual Appointment Appointment { get; set; }
    }
}