using InnoCVExercise.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoCVExercise.DataLayer
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public Context()
        { }

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
    }
}
