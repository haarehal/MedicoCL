using MedicoCL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedicoCL.Dtos
{
    public class TestResultDto
    {
        [ForeignKey("AppointmentDto")]
        public int TestResultId { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int AppointmentId { get; set; }

        [JsonIgnore]
        public virtual AppointmentDto Appointment { get; set; }
    }
}