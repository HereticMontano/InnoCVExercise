using InnoCVExercise.DataLayer.Entities;
using InnoCVExercise.DataLayer.Interfaces;
using System.Collections.Generic;

namespace InnoCVExercise.DataLayer.Provider
{
    public class UserProvider : BaseProvider, IBaseWriteProvider<User, int>
    {

        public UserProvider(Context unitOfWork) : base(unitOfWork)
        {
        }

        public User Add(User entity)
        {
            return _unitOfWork.User.Add(entity).Entity;
        }

        public User GetById(int id)
        {
            return _unitOfWork.User.Find(id);
        }

        public void Update(User entity)
        {
            _unitOfWork.Update(entity);
        }

        public void Delete(int id)
        {
            _unitOfWork.User.Remove(new User { Id = id });
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.User;
        }
    }
}
