using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace task1.Models
{
    public class TraineeContext:IdentityDbContext
    {
        public TraineeContext(DbContextOptions<TraineeContext>option):base(option) { }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public DbSet<task1.ViewModels.SignUpAuthViewModel>? SignUpAuthViewModel { get; set; }
        public DbSet<task1.ViewModels.LogInAuthViewModel>? LogInAuthViewModel { get; set; }



    }
}
