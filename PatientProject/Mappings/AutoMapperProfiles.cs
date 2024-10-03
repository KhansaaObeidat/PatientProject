using AutoMapper;
using PatientProject.Models;
using PatientProject.Models.Dtos;

namespace PatientProject.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Patient,PatientDto>().ReverseMap();
            CreateMap<AddPatientDto, Patient>().ReverseMap();
            CreateMap<UpdatePatientDto, Patient>().ReverseMap();
        }
    }
}
