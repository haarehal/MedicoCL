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
    public class AppointmentsController : ApiController
    {
        public ApplicationDbContext _context;

        public AppointmentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/appointments
        public IHttpActionResult GetAppointments(string dateBegin = null, string dateEnd = null)
        {
            var appointmentsQuery = _context.Appointments.Include(a => a.Patient).Include(a => a.Medic).Include(a => a.TestResult);

            if(!String.IsNullOrWhiteSpace(dateBegin) && String.IsNullOrWhiteSpace(dateEnd) || String.IsNullOrWhiteSpace(dateBegin) && !String.IsNullOrWhiteSpace(dateEnd))
            {
                return BadRequest();
            }
            else if (!String.IsNullOrWhiteSpace(dateBegin) && !String.IsNullOrWhiteSpace(dateEnd)) 
            {
                var db = DateTime.Parse(dateBegin);
                var de = DateTime.Parse(dateEnd);

                appointmentsQuery = appointmentsQuery.Where(a => a.DateAndTime >= db && a.DateAndTime <= de);
            }

            return Ok(appointmentsQuery.ToList().Select(Mapper.Map<Appointment, AppointmentDto>));
        }

        // GET /api/appointments/{id}
        public IHttpActionResult GetAppointment(int id)
        {
            var appointmentInDb = _context.Appointments.SingleOrDefault(a => a.Id == id);

            if (appointmentInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Appointment, AppointmentDto>(appointmentInDb));
        }

        // POST /api/appointments
        [HttpPost]
        public IHttpActionResult CreateAppointment(AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var appointment = Mapper.Map<AppointmentDto, Appointment>(appointmentDto);

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            appointmentDto.Id = appointment.Id;

            return Created(new Uri(Request.RequestUri + "/" + appointmentDto.Id), appointmentDto);
        }

        // PUT /api/appointments/{id}
        [HttpPut]
        public IHttpActionResult UpdateAppointment(int id, AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var appointmentInDb = _context.Appointments.SingleOrDefault(a => a.Id == id);

            if (appointmentInDb == null)
            {
                return NotFound();
            }

            appointmentInDb.DateAndTime = appointmentDto.DateAndTime;
            appointmentInDb.MedicId = appointmentDto.MedicId;
            appointmentInDb.PatientId = appointmentDto.PatientId;
            //appointmentInDb.TestResult = appointmentDto.TestResult;
            appointmentInDb.IsUrgent = appointmentDto.IsUrgent;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/appointments/{id}
        [HttpDelete]
        public IHttpActionResult DeleteAppointment(int id)
        {
            var appointmentInDb = _context.Appointments.SingleOrDefault(a => a.Id == id);

            if (appointmentInDb == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointmentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
