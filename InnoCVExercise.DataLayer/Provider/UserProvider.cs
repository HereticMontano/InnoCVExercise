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
            con respecto a que no me permite actualizar la entidad de forma directa, porque el objeto orignal esta siendo trackeada 
            sopecho que tiene algo que ver con el manejo de la base en memoria y su persistencia*/
            var tracked = UnitOfWork.User.Find(entity.Id);
            if (tracked != null)
            {
                tracked.Name = entity.Name;
                tracked.Birthdate = entity.Birthdate;
                UnitOfWork.User.Update(entity);
            }
        }

        public void Delete(int id)
        {
            /*Esta busqueda es un FIX para un problema que me da de lado de unitest,
            con respecto a que no me permite eliminar la entidad de forma directa, porque el objeto orignal esta siendo trackeada 
            sopecho que tiene algo que ver con el manejo de la base en memoria y su persistencia  */
            var tracked = UnitOfWork.User.Find(id);
            if (tracked != null)
                UnitOfWork.User.Remove(tracked);
        }

        public IEnumerable<User> GetAll()
        {
            return UnitOfWork.User;
        }
    }
}
