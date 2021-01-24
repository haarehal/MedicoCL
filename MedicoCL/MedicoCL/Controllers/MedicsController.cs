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
    public class MedicsController : Controller
    {
        private ApplicationDbContext _context;

        public MedicsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Record()
        {
            var medicsInDb = _context.Medics.Include(m => m.Title).ToList();

            return View("Record", medicsInDb);
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult New()
        {
            var titlesInDb = _context.Titles.ToList();

            var medicFormviewModel = new MedicFormViewModel
            {
                Medic = new Medic(),
                Titles = titlesInDb
            };

            return View("Form", medicFormviewModel);
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Edit(int id)
        {
            var medicInDb = _context.Medics.Include(m => m.Title).SingleOrDefault(m => m.Id == id);

            if (medicInDb == null)
            {
                return HttpNotFound();
            }

            var titlesInDb = _context.Titles.ToList();

            var medicFormviewModel = new MedicFormViewModel
            {
                Medic = medicInDb,
                Titles = titlesInDb
            };

            return View("Form", medicFormviewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Create(Medic medic)
        {
            if (!ModelState.IsValid)
            {
                var medicFormViewModel = new MedicFormViewModel
                {
                    Medic = medic,
                    Titles = _context.Titles.ToList()
                };

                return View("Form", medicFormViewModel);
            }

            _context.Medics.Add(medic);
            _context.SaveChanges();

            return RedirectToAction("Record", "Medics");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Update(Medic medic)
        {
            if (!ModelState.IsValid)
            {
                var medicFormViewModel = new MedicFormViewModel
                {
                    Medic = medic,
                    Titles = _context.Titles.ToList()
                };

                return View("Form", medicFormViewModel);
            }

            var medicInDb = _context.Medics.Single(m => m.Id == medic.Id);

            medicInDb.FirstName = medic.FirstName;
            medicInDb.LastName = medic.LastName;
            medicInDb.TitleId = medic.TitleId;
            medicInDb.Code = medic.Code;

            _context.SaveChanges();

            return RedirectToAction("Record", "Medics");
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult Delete(int id)
        {
            var medicInDb = _context.Medics.Include(m => m.Title).SingleOrDefault(m => m.Id == id);

            if (medicInDb == null)
            {
                return HttpNotFound();
            }

            _context.Medics.Remove(medicInDb);
            _context.SaveChanges();

            return RedirectToAction("Record", "Medics");
        }
    }
}