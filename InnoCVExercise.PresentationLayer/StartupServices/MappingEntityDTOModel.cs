using AutoMapper;
using InnoCVExercise.DataLayer.Entities;
using InnoCVExercise.PresentationLayer.Models;
using InnoCVExercise.DomainLayer.DTOs;

namespace InnoCVExercise.StartupServices
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
