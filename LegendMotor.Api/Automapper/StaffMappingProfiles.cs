using AutoMapper;
using LegendMotor.Api.Dtos;
using LegendMotor.Domain.Models;
namespace LegendMotor.Api.Automapper
{
    public class StaffMappingProfiles : Profile
    {
        public StaffMappingProfiles()
        {
            CreateMap<StaffCreateDto, Staff>();
        }
    }
}
