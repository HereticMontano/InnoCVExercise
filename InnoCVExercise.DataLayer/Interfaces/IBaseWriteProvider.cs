
namespace InnoCVExercise.DataLayer.Interfaces
{
    public interface IBaseWriteProvider<T, I> : IBaseReadProvider<T, I>
    {
        T Add(T entity);        

        void Update(T entity);

        void Delete(I id);        
    }
}
