using AutoMapper;
using HospitalWebAPI.Models;

namespace HospitalWebAPI.Classes
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Appointment, object>();
			CreateMap<AppointmentDisease, Object>();
			CreateMap<Comment, Object>();
			CreateMap<Department, Object>();
			CreateMap<Disease, Object>();
			CreateMap<Employee, Object>();
			CreateMap<Equipment, Object>();
			CreateMap<Gender, Object>();
			CreateMap<History, Object>();
			CreateMap<Instruction, Object>();
			CreateMap<Patient, Object>();
			CreateMap<Payment, Object>();
			CreateMap<Service, Object>();
		}
	}
}
