using AutoMapper;
using InnoCVExercise.Models;
using InnoCVExercise.Service.DTOs;

namespace InnoCVExercise.StartupService
{
    public class MappingDTOViewModel : Profile
    {
        public MappingDTOViewModel()
        {            
            CreateMap<UserModel, UserDTO>();
            CreateMap<UserDTO, UserModel>();
        }
    }
}
