using System.Collections.Generic;

namespace InnoCVExercise.DomainLayer.Interfaces
{
    public interface ICommonService<T, I>
    {
        IEnumerable<T> GetAll();

        T GetById(I id);

        T Add(T dto);

        void Update(T dto);

        void Delete(I id);                
    }
}
