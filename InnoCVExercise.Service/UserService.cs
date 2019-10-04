using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Entities;
using InnoCVExercise.DataLayer.Interfaces;
using InnoCVExercise.DataLayer.Provider;
using InnoCVExercise.Service.DTOs;
using InnoCVExercise.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InnoCVExercise.Service
{
    public class UserService : BaseService, IUserService
    {
        private IBaseWriteProvider<User, int> UserProvider { get; set; }

        public UserService(Context unitiOfWork, IBaseWriteProvider<User, int> userProvider, IMapper mapper) : base(unitiOfWork, mapper)
        {
            UserProvider = new UserProvider(unitiOfWork);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return UserProvider.GetAll().Select(x => _mapper.Map<UserDTO>(x));
        }

        public UserDTO GetById(int id)
        {
            return _mapper.Map<UserDTO>(UserProvider.GetById(id));
        }

        public UserDTO Add(UserDTO dto)
        {
            var newUser = _mapper.Map<User>(dto);
            var entity = UserProvider.Add(newUser);
            SaveChanges();

            return _mapper.Map<UserDTO>(entity);
        }

        public void Update(UserDTO dto)
        {
            var updatedUser = _mapper.Map<User>(dto);
            UserProvider.Update(updatedUser);
        }

        public void Delete(int id)
        {
            UserProvider.Delete(id);
            SaveChanges();
        }           
    }
}
