using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicoCL.Models;
using MedicoCL.Dtos;

namespace MedicoCL.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<PatientDto, Patient>().ForMember(p => p.Id, opt => opt.Ignore());

            Mapper.CreateMap<Medic, MedicDto>();
            Mapper.CreateMap<MedicDto, Medic>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Gender, GenderDto>();

            Mapper.CreateMap<Title, TitleDto>();

            Mapper.CreateMap<Appointment, AppointmentDto>();
            Mapper.CreateMap<AppointmentDto, Appointment>().ForMember(a => a.Id, opt => opt.Ignore());

            Mapper.CreateMap<TestResult, TestResultDto>();
            Mapper.CreateMap<TestResultDto, TestResult>().ForMember(tr => tr.TestResultId, opt => opt.Ignore());
        }
    }
}