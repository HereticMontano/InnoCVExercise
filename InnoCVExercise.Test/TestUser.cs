using InnoCVExercise.PresentationLayer.Controllers;
using InnoCVExercise.PresentationLayer.Models;
using InnoCVExercise.Test.Helpers;
using System.Linq;
using Xunit;

namespace InnoCVExercise.Test
{
    public class TestUser : BaseTest
    {
        int _idTest = 5;

        [Fact]
        public void AddUser()
        {
            using (var userController = new UserController(Manager, Mapp))
            {
                int originalCount = userController.GetUsers().GetValue().Count;
                userController.AddUser(new UserModel { Name = $"Test", Birthdate = DateTimeHelper.RandomDay() });
                Assert.Equal(originalCount + 1, userController.GetUsers().GetValue().Count());
            }
        }

        [Fact]
        public void GetUser()
        {
            using (var userController = new UserController(Manager, Mapp))
            {
                UserModel dbUser = userController.GetUser(_idTest).GetValue();
                Assert.NotNull(dbUser);
            }
        }

        [Fact]
        public void UpdateUser()
        {
            using (var userController = new UserController(Manager, Mapp))
            {
                UserModel originalUser = userController.GetUser(_idTest).GetValue();
                originalUser.Name = "Zapatra";
                originalUser.Birthdate = DateTimeHelper.RandomDay();
                userController.UpdateUser(originalUser);
                UserModel dbUser = userController.GetUser(originalUser.Id).GetValue();
                Assert.True(dbUser.Equals(originalUser));
            }
        }

        [Fact]
        public void Delete()
        {
            using (var userController = new UserController(Manager, Mapp))
            {
                int originalCount = userController.GetUsers().GetValue().Count();
                userController.DeleteUser(_idTest);
                UserModel dbUser = userController.GetUser(_idTest).GetValue();
                Assert.True(dbUser == null && userController.GetUsers().GetValue().Count() < originalCount);
            }
        }
    }
}
