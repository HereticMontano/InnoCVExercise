
namespace InnoCVExercise.DataLayer.Providers
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
