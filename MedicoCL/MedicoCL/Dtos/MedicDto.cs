using MedicoCL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoCL.Dtos
{
    public class MedicDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int TitleId { get; set; }

        [JsonIgnore]
        public virtual TitleDto Title { get; set; }

        [Required]
        public string Code { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}