using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MedicoCL.Models
{
    public class Medic
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Title")]
        public int TitleId { get; set; }

        [JsonIgnore]
        public virtual Title Title { get; set; }

        [Required]
        public string Code { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}