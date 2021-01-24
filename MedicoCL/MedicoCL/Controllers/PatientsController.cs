using MedicoCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MedicoCL.ViewModels;

namespace MedicoCL.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Record()
        {
            var patientsInDb = _context.Patients.Include(p => p.Gender).ToList();

            return View("Record", patientsInDb);
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult New()
        {
            var gendersInDb = _context.Genders.ToList();

            var patientFormviewModel = new PatientFormViewModel
            {
                Patient = new Patient(),
                Genders = gendersInDb
            };

            return View("Form", patientFormviewModel);
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Edit(int id)
        {
            var patientInDb = _context.Patients.Include(p => p.Gender).SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
            {
                return HttpNotFound();
            }

            var gendersInDb = _context.Genders.ToList();

            var patientFormViewModel = new PatientFormViewModel
            {
                Patient = patientInDb,
                Genders = gendersInDb
            };

            return View("Form", patientFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var patientFormViewModel = new PatientFormViewModel
                {
                    Patient = patient,
                    Genders = _context.Genders.ToList()
                };

                return View("Form", patientFormViewModel);
            }

            if(patient.Address == null)
            {
                patient.Address = "/";
            }

            if (patient.PhoneNumber == null)
            {
                patient.PhoneNumber = "/";
            }

            _context.Patients.Add(patient);
            _context.SaveChanges();

            return RedirectToAction("Record", "Patients");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Update(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var patientFormViewModel = new PatientFormViewModel
                {
                    Patient = patient,
                    Genders = _context.Genders.ToList()
                };

                return View("Form", patientFormViewModel);
            }

            var patientInDb = _context.Patients.Single(m => m.Id == patient.Id);

            patientInDb.FirstName = patient.FirstName;
            patientInDb.LastName = patient.LastName;
            patientInDb.Birthdate = patient.Birthdate;
            patientInDb.GenderId = patient.GenderId;
            patientInDb.Address = patient.Address;
            patientInDb.PhoneNumber = patient.PhoneNumber;

            if (patientInDb.Address == null)
            {
                patientInDb.Address = "/";
            }

            if (patientInDb.PhoneNumber == null)
            {
                patientInDb.PhoneNumber = "/";
            }

            _context.SaveChanges();

            return RedirectToAction("Record", "Patients");
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Delete(int id)
        {
            var patientInDb = _context.Patients.Include(p => p.Gender).SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
            {
                return HttpNotFound();
            }

            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();

            return RedirectToAction("Record", "Patients");
        }
    }
}