using MedicoCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicoCL.ViewModels
{
    public class AppointmentFormViewModel
    {
        public Appointment Appointment { get; set; }
        public IEnumerable<Medic> Medics { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public string PageTitle 
        {
            get
            {
                return Appointment.Id == 0 ? "NEW APPOINTMENT" : "EDIT APPOINTMENT";
            }
        }
    }
}