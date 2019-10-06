using InnoCVExercise.DataLayer.Entities;
using System;
using System.Linq;

namespace InnoCVExercise.DataLayer.Mocks
{
    public static class DataGenerator
    {

        public static void Initialize(Context unitiOfWork)
        {
            if (!unitiOfWork.User.Any())
            {
                unitiOfWork.User.AddRange(
         new User { Name = "Diego", Birthdate = DateTime.Now },
         new User { Name = "Juan", Birthdate = DateTime.Now },
         new User { Name = "Virginia", Birthdate = DateTime.Now },
         new User { Name = "Ulises", Birthdate = DateTime.Now },
         new User { Name = "Daniela", Birthdate = DateTime.Now },
         new User { Name = "Pepe", Birthdate = DateTime.Now },
         new User { Name = "Manuel", Birthdate = DateTime.Now },
         new User { Name = "Leonardo", Birthdate = DateTime.Now }
                );

                unitiOfWork.SaveChanges();
            }
        }
    }
}
