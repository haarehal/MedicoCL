using MedicoCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicoCL.ViewModels
{
    public class TestResultFormViewModel
    {
        private TestResult testResult;
        private int appointmentId;

        public TestResult TestResult
        {
            get
            {
                return testResult;
            }

            set
            {
                testResult = value;
            }
        }

        public int AppointmentId
        {
            get
            {
                return appointmentId;
            }

            set
            {
                appointmentId = value;
            }
        }

        public void SetAppointmentIdForTestResult(int id)
        {
            if(testResult != null) testResult.AppointmentId = id;
        }

        public string PageTitle
        {
            get
            {
                return (TestResult == null || TestResult.TestResultId == 0) ? "CREATE TEST RESULT" : "EDIT TEST RESULT";
            }
        }
    }
}