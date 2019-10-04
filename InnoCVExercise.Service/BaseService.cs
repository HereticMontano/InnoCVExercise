using AutoMapper;
using InnoCVExercise.DataLayer;

namespace InnoCVExercise.Service
{
    public class BaseService
    {
        private Context _context;
        protected readonly IMapper _mapper;

        public BaseService(Context context, IMapper mapper)
        {
            _mapper = mapper;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
