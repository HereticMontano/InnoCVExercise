using InnoCVExercise.DataLayer.Entities;
using InnoCVExercise.DataLayer.Interfaces;
using System.Collections.Generic;

namespace InnoCVExercise.DataLayer.Provider
{
    public class UserProvider : BaseProvider, IUserProvider
    {

        public UserProvider(Context unitOfWork) : base(unitOfWork)
        {
        }

        public User Add(User entity)
        {            
            return UnitOfWork.User.Add(entity).Entity;
        }

        public User GetById(int id)
        {
            return UnitOfWork.User.Find(id);
        }

        public void Update(User entity)
        {
            UnitOfWork.Update(entity);
        }

        public void Delete(int id)
        {
            UnitOfWork.User.Remove(new User { Id = id });
        }

        public IEnumerable<User> GetAll()
        {
            return UnitOfWork.User;
        }
    }
}
