using AutoMapper;
using InnoCVExercise.DataLayer.Entities;
using InnoCVExercise.Models;
using InnoCVExercise.Service.DTOs;

namespace InnoCVExercise.StartupService
{
    public class MappingEntityDTOModel : Profile
    {
        public MappingEntityDTOModel()
        {
            #region User
            CreateMap<UserModel, UserDTO>();
            CreateMap<UserDTO, UserModel>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            #endregion
        }
    }
}
