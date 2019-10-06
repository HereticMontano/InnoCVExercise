using InnoCVExercise.PresentationLayer.Controllers;
using InnoCVExercise.PresentationLayer.Models;
using InnoCVExercise.Test.Helpers;
using System.Linq;
using Xunit;

namespace InnoCVExercise.Test
{
    public class TestUser : BaseTest
    {

        [Fact]
        public void CRUDUser()
        {
            int idTest = 5;

            AddUser();
            GetUser(idTest);
            UpdateUser(idTest);
            Delete(idTest);
        }

        private void AddUser()
        {
            using (var userController = new UserController(Manager, Mapp))
            {
                int originalCount = userController.GetUsers().GetValue().Count;
                userController.AddUser(new UserModel { Name = $"Test", Birthdate = DateTimeHelper.RandomDay() });
                Assert.Equal(originalCount + 1, userController.GetUsers().GetValue().Count());
            }
        }

        private void GetUser(int idTest)
        {
            using (var userController = new UserController(Manager, Mapp))
            {
                UserModel dbUser = userController.GetUser(idTest).GetValue();
                Assert.NotNull(dbUser);
            }
        }

        private void UpdateUser(int idTest)
        {
            using (var userController = new UserController(Manager, Mapp))
            {

                UserModel originalUser = userController.GetUser(idTest).GetValue();
                originalUser.Name = "Zapatra";
                originalUser.Birthdate = DateTimeHelper.RandomDay();
                userController.UpdateUser(originalUser);
                UserModel dbUser = userController.GetUser(originalUser.Id).GetValue();
                Assert.True(dbUser.Equals(originalUser));
            }
        }

        private void Delete(int idTest)
        {
            using (var userController = new UserController(Manager, Mapp))
            {
                int originalCount = userController.GetUsers().GetValue().Count();
                userController.DeleteUser(idTest);
                UserModel dbUser = userController.GetUser(idTest).GetValue();
                Assert.True(dbUser == null && userController.GetUsers().GetValue().Count() < originalCount);
            }
        }
    }
}
