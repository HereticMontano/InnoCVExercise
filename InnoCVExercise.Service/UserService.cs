using AutoMapper;
using InnoCVExercise.Provider;
using InnoCVExercise.Provider.Entities;
using InnoCVExercise.Service.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace InnoCVExercise.Service
{
    public class UserService : BaseService, IBaseService<UserDTO>
    {

        public UserService(Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public void Add(UserDTO url)
        {
            var newUser = _mapper.Map<User>(url);
            _context.User.Add(newUser);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.User.Remove(new User { Id = id });
            _context.SaveChanges();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _context.User.Select(x => _mapper.Map<UserDTO>(x)).ToList();
        }
    }
}
