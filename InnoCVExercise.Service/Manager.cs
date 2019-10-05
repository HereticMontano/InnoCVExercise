using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Provider;
using InnoCVExercise.Service.Interfaces;

namespace InnoCVExercise.Service
{
    public class Manager
    {   
        public IUserService UserService { get;  private set; }

        public Manager(Context unitOfWork, IMapper mapper)
        {
            UserService = new UserService(unitOfWork, new UserProvider(unitOfWork), mapper);
        }        
    }
}
