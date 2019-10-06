using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Providers;
using InnoCVExercise.DomainLayer.Interfaces;
using InnoCVExercise.DomainLayer.Services;

namespace InnoCVExercise.DomainLayer
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
