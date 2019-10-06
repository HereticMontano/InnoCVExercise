using AutoMapper;
using InnoCVExercise.DataLayer;
using System.Threading.Tasks;

namespace InnoCVExercise.DomainLayer.Services
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

        public async Task SaveChangesAsync()
        {
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
