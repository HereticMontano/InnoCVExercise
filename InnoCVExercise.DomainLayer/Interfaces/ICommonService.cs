using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnoCVExercise.DomainLayer.Interfaces
{
    public interface ICommonService<T, I>
    {
        IEnumerable<T> GetAll();

        T GetById(I id);

        Task<T> AddAsync(T dto);

        Task UpdateAsync(T dto);

        Task DeleteAsync(I id);                
    }
}
