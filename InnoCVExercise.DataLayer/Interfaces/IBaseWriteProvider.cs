
using System.Threading.Tasks;

namespace InnoCVExercise.DataLayer.Interfaces
{
    public interface IBaseWriteProvider<T, I> : IBaseReadProvider<T, I>
    {
        Task<T> AddAsync(T entity);        

        void Update(T entity);

        void Delete(I id);        
    }
}
