
using System.Threading.Tasks;

namespace InnoCVExercise.DataLayer.Interfaces
{
    public interface IBaseWriteProvider<T, I> : IBaseReadProvider<T, I>
    {
        Task<T> AddAsync(T entity);        

        void UpdateAsync(T entity);

        void DeleteAsync(I id);        
    }
}
