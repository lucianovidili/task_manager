using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;

namespace TaskManagerApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    Id = 1,
                    Title = "My first task",
                    Description = "This is my first task to get started with the task manager.",
                    DueDate = DateTime.Now.AddDays(7),
                    IsCompleted = false
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Complete project documentation",
                    Description = "Write comprehensive documentation for the current project.",
                    DueDate = DateTime.Now.AddDays(14),
                    IsCompleted = false
                },
                new TaskItem
                {
                    Id = 3,
                    Title = "Review code changes",
                    Description = "Review and approve pending code changes in the repository.",
                    DueDate = DateTime.Now.AddDays(3),
                    IsCompleted = true
                }
            );
        }
    }
}