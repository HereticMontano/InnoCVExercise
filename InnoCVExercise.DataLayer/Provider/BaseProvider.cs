
namespace InnoCVExercise.DataLayer.Provider
{
    public class BaseProvider
    {
        protected Context UnitOfWork { get; }
  
        public BaseProvider(Context unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }      
    }
}
