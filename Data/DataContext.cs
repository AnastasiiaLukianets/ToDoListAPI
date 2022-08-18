using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        { }

        public DbSet<TaskToDo> TasksToDo { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add the shadow property to the model
            //modelBuilder.Entity<TaskToDo>().Property<int>("UserForeignKey");

            // Use the shadow property as a foreign key
            /*
            modelBuilder.Entity<TaskToDo>()
                .HasOne(t => t.UserId)
                .WithMany(u => u.Tasks)
                .HasForeignKey("UserForeignKey")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);
            */
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne();
        }
    }
}
