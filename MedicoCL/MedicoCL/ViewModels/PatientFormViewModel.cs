using MedicoCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicoCL.ViewModels
{
    public class PatientFormViewModel
    {
        public Patient Patient { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public string PageTitle
        {
            get
            {
                return Patient.Id == 0 ? "NEW PATIENT" : "EDIT PATIENT";
            }
        }
    }
}