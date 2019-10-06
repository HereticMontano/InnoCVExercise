using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Entities;
using InnoCVExercise.DataLayer.Interfaces;
using InnoCVExercise.DomainLayer.DTOs;
using InnoCVExercise.DomainLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var res = UserProvider.GetAllAsync();
            return res.Result.Select(x => Mapper.Map<UserDTO>(x));
        }

        public UserDTO GetById(int id)
        {
            return Mapper.Map<UserDTO>(UserProvider.GetByIdAsync(id).Result);
        }

        public async Task<UserDTO> AddAsync(UserDTO dto)
        {
            var newUser = Mapper.Map<User>(dto);
            var entity = UserProvider.AddAsync(newUser);
            await SaveChangesAsync();

            return Mapper.Map<UserDTO>(entity);
        }

        public async Task UpdateAsync(UserDTO dto)
        {
            var updatedUser = Mapper.Map<User>(dto);
            UserProvider.UpdateAsync(updatedUser);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            UserProvider.DeleteAsync(id);
            await SaveChangesAsync();
        }
    }
}
