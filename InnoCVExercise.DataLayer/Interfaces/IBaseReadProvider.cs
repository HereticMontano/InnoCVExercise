
using System.Collections.Generic;

namespace InnoCVExercise.DataLayer.Interfaces
{
    public interface IBaseReadProvider<T, I>
    {
        IEnumerable<T> GetAll();

        T GetById(I id);
    }
}
