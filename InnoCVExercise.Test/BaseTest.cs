using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Mocks;
using InnoCVExercise.DomainLayer;
using InnoCVExercise.StartupServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InnoCVExercise.Test
{
    public class BaseTest
    {
        protected IMapper Mapp { get; set; }

        protected Manager Manager
        {
            get
            {
                var serviceProvider = new ServiceCollection()
                   .AddEntityFrameworkInMemoryDatabase()
                   .BuildServiceProvider();

                var builder = new DbContextOptionsBuilder<Context>();
                builder = builder.UseInMemoryDatabase("DataBase").UseInternalServiceProvider(serviceProvider);
                var con = new Context(builder.Options);
                DataGenerator.Initialize(con);
                return new Manager(con, Mapp);
            }
        }

        public BaseTest()
        {
            Mapp = new MapperConfiguration(cfg => { cfg.AddProfile<MappingEntityDTOModel>(); }).CreateMapper();
        }      
    }
}
