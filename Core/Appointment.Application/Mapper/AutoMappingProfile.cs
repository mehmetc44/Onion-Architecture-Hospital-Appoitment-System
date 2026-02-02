using System;
using AutoMapper;
using Appointment.Application.DTO.Appoitment;
using Appointment.Application.DTO.HospitalAppoitment;
using Appointment.Domain.Entities;
using Appointment.Domain.Enums;
using Appointment.Domain.Entities.Identity;
using Appointment.Application.DTO;
namespace Appointment.Application.Mapper;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<CreateHospitalAppointmentDto, HospitalAppointment>()
            // Tarihin sadece Date kısmını alıyoruz
            .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.AppointmentDate.Date));
        
        CreateMap<UpdateHospitalAppointmentDto, HospitalAppointment>()
            // Tarihin sadece Date kısmını alıyoruz
            .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.AppointmentDate.Date))
            // UpdatedDate'i DTO'dan almıyoruz, servis içinde elle atayacağız, o yüzden Ignore diyoruz (Opsiyonel ama güvenli)
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore());
        CreateMap<HospitalAppointment, UpdateHospitalAppointmentDto>();

        CreateMap<HospitalAppointment, ViewHospitalAppointmentDto>()
            // İlişkili tablolardan veri çekme kuralları (Projection)
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Hospital.City.Name))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.Hospital.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => $"{src.Doctor.User.FirstName} {src.Doctor.User.LastName}"))
            .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Doctor.Id))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)); 
        CreateMap<AspUser, ViewUserInfoDto>();
    }
}

