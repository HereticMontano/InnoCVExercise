
namespace InnoCVExercise.DataLayer.Provider
{
    public class BaseProvider
    {
        protected Context _unitOfWork;
  
        public BaseProvider(Context unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }      
    }
}
