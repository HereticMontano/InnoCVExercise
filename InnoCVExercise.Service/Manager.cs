using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Provider;
using InnoCVExercise.Service.Interfaces;

namespace InnoCVExercise.Service
{
    public class Manager
    {
        public IUserService IUserService { get;  private set; }

        public Manager(Context unityOfWork, IMapper mapper)
        {
            IUserService = new UserService(unityOfWork, new UserProvider(unityOfWork), mapper);
        }
    }
}
