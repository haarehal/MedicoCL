using MedicoCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicoCL.ViewModels
{
    public class MedicFormViewModel
    {
        public Medic Medic { get; set; }
        public IEnumerable<Title> Titles { get; set; }
        public string PageTitle
        {
            get
            {
                return Medic.Id == 0 ? "NEW MEDIC" : "EDIT MEDIC";
            }
        }
    }
}