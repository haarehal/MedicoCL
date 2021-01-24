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
    public class MedicsController : ApiController
    {
        public ApplicationDbContext _context;

        public MedicsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/medics
        public IEnumerable<MedicDto> GetMedics(string query = null)
        {
            var medicsQuery = _context.Medics.Include(m => m.Title);

            if (!String.IsNullOrWhiteSpace(query)) medicsQuery = medicsQuery.Where(m => (m.FirstName + " " + m.LastName).Contains(query));

            return medicsQuery.ToList().Select(Mapper.Map<Medic, MedicDto>);
        }

        // GET /api/medics/{id}
        public IHttpActionResult GetMedic(int id)
        {
            var medicInDb = _context.Medics.SingleOrDefault(m => m.Id == id);

            if (medicInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Medic, MedicDto>(medicInDb));
        }

        // POST /api/medics
        [HttpPost]
        public IHttpActionResult CreateMedic(MedicDto medicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var medic = Mapper.Map<MedicDto, Medic>(medicDto);

            _context.Medics.Add(medic);
            _context.SaveChanges();

            medicDto.Id = medic.Id;

            return Created(new Uri(Request.RequestUri + "/" + medicDto.Id), medicDto);
        }

        // PUT /api/medics/{id}
        [HttpPut]
        public IHttpActionResult UpdateMedic(int id, MedicDto medicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var medicInDb = _context.Medics.SingleOrDefault(m => m.Id == id);

            if (medicInDb == null)
            {
                return NotFound();
            }

            Mapper.Map<MedicDto, Medic>(medicDto, medicInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/medics/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMedic(int id)
        {
            var medicInDb = _context.Medics.SingleOrDefault(m => m.Id == id);

            if (medicInDb == null)
            {
                return NotFound();
            }

            _context.Medics.Remove(medicInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
