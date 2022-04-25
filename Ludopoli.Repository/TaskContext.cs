using Ludopoli.Core;

using Microsoft.EntityFrameworkCore;

namespace Ludopoli.Repository
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
          
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().HasData(
                new Priority
                {
                    Id=1,Name="Low"
                },
                 new Priority
                 {
                     Id = 2,
                     Name = "Medium"
                 },
                  new Priority
                  {
                      Id = 3,
                      Name = "High"
                  },
                   new Priority
                   {
                       Id = 4,
                       Name = "Urgent"
                   }

            );

            modelBuilder.Entity<Status>().HasData(
              new Status
              {
                  Id = 1,
                  Name = "Not Start"
              },
               new Status
               {
                   Id = 2,
                   Name = "In Progress"
               },
                new Status
                {
                    Id = 3,
                    Name = "Completed"
                }

          );
        }

        public DbSet<TaskEntity> TaskEntities { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
