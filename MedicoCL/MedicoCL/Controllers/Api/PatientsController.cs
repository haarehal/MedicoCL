using MedicoCL.Dtos;
using MedicoCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

namespace MedicoCL.Controllers.Api
{
    public class PatientsController : ApiController
    {
        public ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/patients
        public IEnumerable<PatientDto> GetPatients(string query = null)
        {
            var patientsQuery = _context.Patients.Include(p => p.Gender);

            if (!String.IsNullOrWhiteSpace(query)) patientsQuery = patientsQuery.Where(p => (p.FirstName + " " + p.LastName).Contains(query));

            return patientsQuery.ToList().Select(Mapper.Map<Patient, PatientDto>);
        }

        // GET /api/patients/{id}
        public IHttpActionResult GetPatient(int id)
        {
            var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Patient, PatientDto>(patientInDb));
        }

        // POST /api/patients
        [HttpPost]
        public IHttpActionResult CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var patient = Mapper.Map<PatientDto, Patient>(patientDto);

            _context.Patients.Add(patient);
            _context.SaveChanges();

            patientDto.Id = patient.Id;

            return Created(new Uri(Request.RequestUri + "/" + patientDto.Id), patientDto);
        }

        // PUT /api/patients/{id}
        [HttpPut]
        public IHttpActionResult UpdatePatient(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
            {
                return NotFound();
            }

            Mapper.Map<PatientDto, Patient>(patientDto, patientInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/patients/{id}
        [HttpDelete]
        public IHttpActionResult DeletePatient(int id)
        {
            var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
