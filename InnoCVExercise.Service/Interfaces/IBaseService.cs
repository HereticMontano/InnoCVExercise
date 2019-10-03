
using System.Collections.Generic;

namespace InnoCVExercise.Service
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();
    }
}
