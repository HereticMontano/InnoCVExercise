using AutoMapper;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DomainLayer;
using InnoCVExercise.PresentationLayer;
using InnoCVExercise.PresentationLayer.Controllers;
using InnoCVExercise.PresentationLayer.Models;
using InnoCVExercise.StartupService;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Linq;
using InnoCVExercise.Test.Helpers;
using InnoCVExercise.DataLayer.Mock;
using System.Collections.Generic;

namespace InnoCVExercise.Test
{
    public class Test
    {
        private IMapper Mapp { get; set; }        

        private Manager Manager
        {
            get
            {
                var builder = new DbContextOptionsBuilder<Context>();
                builder = builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).UseInMemoryDatabase(Guid.NewGuid().ToString());
                var con = new Context(builder.Options);
                DataGenerator.Initialize(con);
                return new Manager(con, Mapp);
            }
        }

        public Test()
        {         
            Mapp =  new MapperConfiguration(cfg => { cfg.AddProfile<MappingEntityDTOModel>(); }).CreateMapper();
        }

        [Fact]
        public void CRUDUser()
        {            
            UserModel originalUser;
            UserModel dbUser;
            
            //AddUser
            using (var userController = new UserController(Manager, Mapp))
            {
                int originalCount = userController.GetUsers().Count();                
                userController.AddUser(new UserModel { Name = $"Test", Birthdate = DateTimeHelper.RandomDay() });                

                Assert.Equal(originalCount + 1, userController.GetUsers().Count());
            }
            //GetUser
            using (var userController = new UserController(Manager, Mapp))
            {
                
                originalUser = userController.GetUsers().Last();
                dbUser = userController.GetUser(originalUser.Id);
                Assert.True(dbUser.Equals(originalUser));
            }
            //UpdateUser
            using (var userController = new UserController(Manager, Mapp))
            {
                originalUser.Name = "Zapatra";
                originalUser.Birthdate = DateTimeHelper.RandomDay();
                userController.UpdateUser(originalUser);
                dbUser = userController.GetUser(originalUser.Id);

                Assert.True(dbUser.Equals(originalUser));
            }
            //DeleteUser
            using (var userController = new UserController(Manager, Mapp))
            {
                int originalCount = userController.GetUsers().Count();
                userController.DeleteUser(originalUser.Id);
                dbUser = userController.GetUser(originalUser.Id);                
                Assert.True(dbUser == null && userController.GetUsers().Count() < originalCount);
            }
            //     allUsers = program.GetUsers();

            //Assert.NotEqual(10, allUsers)


        }
    }
}
