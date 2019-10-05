using AutoMapper;
using InnoCVExercise.DataLayer;

namespace InnoCVExercise.DomainLayer
{
    public class BaseService
    {
        private Context UnitOfWork { get; set; }
        protected IMapper Mapper { get; private set; }

        public BaseService(Context unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;            
        }

        public int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }
    }
}
