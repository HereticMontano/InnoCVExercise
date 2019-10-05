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
            /*Esta busqueda y asignacion a mano es un FIX para un problema que me da de lado de unitest,
            con respecto a que no me permite actualizar la entidad de forma directa porque el objeto orignal esta siendo trackeada  */
            var tracked = UnitOfWork.User.Find(entity.Id);
            tracked.Name = entity.Name;
            tracked.Birthdate = entity.Birthdate;
            UnitOfWork.User.Update(entity);            
        }

        public void Delete(int id)
        {
            /*Esta busqueda FIX para un problema que me da de lado de unitest,
            con respecto a que no me permite actualizar la entidad de forma directa porque el objeto orignal esta siendo trackeada  */
            var tracked = UnitOfWork.User.Find(id);
            UnitOfWork.User.Remove(tracked);
        }

        public IEnumerable<User> GetAll()
        {
            return UnitOfWork.User;
        }
    }
}
