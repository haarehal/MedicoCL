using MedicoCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using MedicoCL.Dtos;

namespace MedicoCL.Controllers.Api
{
    public class TestResultsController : ApiController
    {
        public ApplicationDbContext _context;

        public TestResultsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/testResults
        public IEnumerable<TestResultDto> GetTestResults()
        {
            return _context.TestResults.Include(m => m.Appointment).ToList().Select(Mapper.Map<TestResult, TestResultDto>);
        }

        // GET /api/testResults/{id}
        public IHttpActionResult GetTestResult(int id)
        {
            var testResultInDb = _context.TestResults.SingleOrDefault(tr => tr.TestResultId == id);

            if (testResultInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TestResult, TestResultDto>(testResultInDb));
        }

        // POST /api/testResults
        [HttpPost]
        public IHttpActionResult CreateTestResult(TestResultDto testResultDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            TestResult testResult = new TestResult
            {
                TestResultId = testResultDto.TestResultId,
                Description = testResultDto.Description,
                DateOfCreation = DateTime.Now,
                AppointmentId = testResultDto.AppointmentId
            };

            _context.TestResults.Add(testResult);
            _context.SaveChanges();

            testResultDto.DateOfCreation = testResult.DateOfCreation;

            return Created(new Uri(Request.RequestUri + "/" + testResultDto.TestResultId), testResultDto);
        }

        // PUT /api/testResults/{id}
        [HttpPut]
        public IHttpActionResult UpdateTestResult(int id, TestResultDto testResultDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var testResultInDb = _context.TestResults.SingleOrDefault(tr => tr.TestResultId == id);

            if (testResultInDb == null)
            {
                return NotFound();
            }

            testResultInDb.TestResultId = testResultDto.TestResultId;
            testResultInDb.Description = testResultDto.Description;
            testResultInDb.AppointmentId = testResultDto.AppointmentId;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/testResults/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMedic(int id)
        {
            var testResultInDb = _context.TestResults.SingleOrDefault(tr => tr.TestResultId == id);

            if (testResultInDb == null)
            {
                return NotFound();
            }

            _context.TestResults.Remove(testResultInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
