
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnoCVExercise.DataLayer.Interfaces
{
    public interface IBaseReadProvider<T, I>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(I id);
    }
}
