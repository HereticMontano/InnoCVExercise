using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Entities;
using InnoCVExercise.DataLayer.Interfaces;
using InnoCVExercise.DomainLayer.DTOs;
using InnoCVExercise.DomainLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InnoCVExercise.DomainLayer.Services
{
    public class UserService : BaseService, IUserService
    {
        private IUserProvider UserProvider { get; set; }

        public UserService(Context unitOfWork, IUserProvider userProvider, IMapper mapper) : base(unitOfWork, mapper)
        {
            UserProvider = userProvider;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return UserProvider.GetAll().Select(x => Mapper.Map<UserDTO>(x));
        }

        public UserDTO GetById(int id)
        {
            return Mapper.Map<UserDTO>(UserProvider.GetById(id));
        }

        public UserDTO Add(UserDTO dto)
        {
            var newUser = Mapper.Map<User>(dto);
            var entity = UserProvider.Add(newUser);
            SaveChanges();

            return Mapper.Map<UserDTO>(entity);
        }

        public void Update(UserDTO dto)
        {
            var updatedUser = Mapper.Map<User>(dto);
            UserProvider.Update(updatedUser);
            SaveChanges();
        }

        public void Delete(int id)
        {
            UserProvider.Delete(id);
            SaveChanges();
        }           
    }
}
