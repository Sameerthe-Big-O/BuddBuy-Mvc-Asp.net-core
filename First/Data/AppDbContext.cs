

using First.Models;
using Microsoft.EntityFrameworkCore;

namespace First.Data
{

    //remember 
    public class AppDbContext:DbContext
    {

        //calling the constructor
       public AppDbContext(DbContextOptions<AppDbContext> options):base(options)

        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //setting up the many to many relationship
            modelBuilder.Entity<Movie_Actors>().HasKey(am => new {
               am.ActorId,
               am.MovieId
            });

            modelBuilder.Entity<Movie_Actors>().HasOne(m => m.Movie).WithMany(am => am.Movie_Actors).HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Movie_Actors>().HasOne(m => m.Actor).WithMany(am => am.Movie_Actors).HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);

        }
            
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Movie_Actors> Movie_Actors { get; set; }


        public DbSet<Cenima> Cenimas { get; set; }
            
        public DbSet<Producer> Producers { get; set; }
    }
}
