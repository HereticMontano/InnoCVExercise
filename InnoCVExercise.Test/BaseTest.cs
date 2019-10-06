using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Mock;
using InnoCVExercise.DomainLayer;
using InnoCVExercise.StartupService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

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
