using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Provider;
using InnoCVExercise.Service.Interfaces;

namespace InnoCVExercise.Service
{
    public class Manager
    {
        public IUserService IUserService { get;  private set; }

        public Manager(Context unitOfWork, IMapper mapper)
        {
            IUserService = new UserService(unitOfWork, new UserProvider(unitOfWork), mapper);
        }
    }
}
