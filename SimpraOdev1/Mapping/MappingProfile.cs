using AutoMapper;
using SimpraHW1.Api.DTOs;
using SimpraHW1.Core.Entities;

namespace SimpraHW1.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Staff, StaffDTO>();
            CreateMap<StaffDTO, Staff>();        
        }
    }
}
