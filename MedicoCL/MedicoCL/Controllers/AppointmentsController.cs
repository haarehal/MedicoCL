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
    public class AppointmentsController : Controller
    {
        private ApplicationDbContext _context;

        public AppointmentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Record(string dateBegin = null, string dateEnd = null)
        {
            var appointmentsInDb = _context.Appointments.Include(a => a.Patient).Include(a => a.Medic).Include(a => a.TestResult);

            if (!String.IsNullOrWhiteSpace(dateBegin) && !String.IsNullOrWhiteSpace(dateEnd))
            {
                var db = DateTime.Parse(dateBegin);
                var de = DateTime.Parse(dateEnd);

                appointmentsInDb = appointmentsInDb.Where(a => a.DateAndTime >= db && a.DateAndTime <= de);
            }

            return View("Record", appointmentsInDb);
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult New()
        {
            var patientsInDb = _context.Patients.ToList();
            var medicsInDb = _context.Medics.Where(m => m.TitleId == 1).ToList();

            var appointmentViewModel = new AppointmentFormViewModel
            {
                Appointment = new Appointment(),
                Patients = patientsInDb,
                Medics = medicsInDb
            };

            return View("Form", appointmentViewModel);
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Edit(int id)
        {
            var appointmentInDb = _context.Appointments.Include(a => a.Patient).Include(a => a.Medic).Include(a => a.TestResult).SingleOrDefault(m => m.Id == id);

            if (appointmentInDb == null)
            {
                return HttpNotFound();
            }

            var patientsInDb = _context.Patients.ToList();
            var medicsInDb = _context.Medics.Where(m => m.TitleId == 1).ToList();

            var appointmentViewModel = new AppointmentFormViewModel
            {
                Appointment = appointmentInDb,
                Patients = patientsInDb,
                Medics = medicsInDb
            };

            return View("Form", appointmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                var appointmentViewModel = new AppointmentFormViewModel
                {
                    Appointment = appointment,
                    Patients = _context.Patients.ToList(),
                    Medics = _context.Medics.ToList()
                };

                return View("Form", appointmentViewModel);
            }

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("Record", "Appointments");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Update(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                var appointmentViewModel = new AppointmentFormViewModel
                {
                    Appointment = appointment,
                    Patients = _context.Patients.ToList(),
                    Medics = _context.Medics.ToList()
                };

                return View("Form", appointmentViewModel);
            }

            var appointmentInDb = _context.Appointments.Single(a => a.Id == appointment.Id);

            appointmentInDb.DateAndTime = appointment.DateAndTime;
            appointmentInDb.PatientId = appointment.PatientId;
            appointmentInDb.MedicId = appointment.MedicId;
            appointmentInDb.IsUrgent = appointment.IsUrgent;

            _context.SaveChanges();

            return RedirectToAction("Record", "Appointments");
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Cancel(int id)
        {
            var appointmentInDb = _context.Appointments.Include(a => a.Patient).Include(a => a.Medic).Include(a => a.TestResult).SingleOrDefault(a => a.Id == id);

            if (appointmentInDb == null)
            {
                return HttpNotFound();
            }

            _context.Appointments.Remove(appointmentInDb);
            _context.SaveChanges();

            return RedirectToAction("Record", "Appointments");
        }
    }
}