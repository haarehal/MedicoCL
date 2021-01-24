using MedicoCL.Models;
using MedicoCL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MedicoCL.Controllers
{
    public class TestResultsController : Controller
    {
        private ApplicationDbContext _context;

        public TestResultsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Record(int appointmentId)
        {
            var testResultInDb = _context.TestResults.SingleOrDefault(tr => tr.AppointmentId == appointmentId);

            var testResultViewModel = new TestResultFormViewModel
            {
                TestResult = testResultInDb,
                AppointmentId = appointmentId
            };

            testResultViewModel.SetAppointmentIdForTestResult(appointmentId);

            return View("Record", testResultViewModel);
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult New(int appointmentId)
        {
            var testResultViewModel = new TestResultFormViewModel
            {
                TestResult = new TestResult(),
                AppointmentId = appointmentId
            };

            testResultViewModel.SetAppointmentIdForTestResult(appointmentId);

            return View("Form", testResultViewModel);
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Edit(int appointmentId)
        {
            var testResultInDb = _context.TestResults.SingleOrDefault(tr => tr.TestResultId == appointmentId);

            if (testResultInDb == null)
            {
                return HttpNotFound();
            }

            var testResultViewModel = new TestResultFormViewModel
            {
                TestResult = testResultInDb,
                AppointmentId = appointmentId
            };

            return View("Form", testResultViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Create(TestResultFormViewModel testResultFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", testResultFormViewModel);
            }

            var appointmentInDb = _context.Appointments.SingleOrDefault(a => a.Id == testResultFormViewModel.TestResult.AppointmentId);

            if (appointmentInDb == null)
            {
                return HttpNotFound();
            }

            testResultFormViewModel.TestResult.DateOfCreation = DateTime.Now;
            testResultFormViewModel.TestResult.TestResultId = appointmentInDb.Id;

            _context.TestResults.Add(testResultFormViewModel.TestResult);
            _context.SaveChanges();

            return RedirectToAction("Record", "Appointments");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Update(TestResultFormViewModel testResultFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", testResultFormViewModel);
            }

            var testResultInDb = _context.TestResults.Single(tr => tr.TestResultId == testResultFormViewModel.TestResult.TestResultId);

            if (testResultInDb == null)
            {
                return HttpNotFound();
            }

            testResultInDb.Description = testResultFormViewModel.TestResult.Description;

            _context.SaveChanges();

            return RedirectToAction("Record", "TestResults", new { appointmentId = testResultFormViewModel.TestResult.AppointmentId });
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Delete(int testResultId)
        {
            var testResultInDb = _context.TestResults.SingleOrDefault(tr => tr.TestResultId == testResultId);

            if (testResultInDb == null)
            {
                return HttpNotFound();
            }

            _context.TestResults.Remove(testResultInDb);
            _context.SaveChanges();

            return RedirectToAction("Record", "Appointments");
        }
    }
}