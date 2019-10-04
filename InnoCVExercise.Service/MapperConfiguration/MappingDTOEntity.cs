using AutoMapper;
using InnoCVExercise.DataLayer.Entities;
using InnoCVExercise.Service.DTOs;

namespace InnoCVExercise.StartupService
{
    public class MappingDTOEntity : Profile
    {
        public MappingDTOEntity()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
