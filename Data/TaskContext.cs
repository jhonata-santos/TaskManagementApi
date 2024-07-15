using Microsoft.EntityFrameworkCore;

namespace TaskManagementApi.Data;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> opts) : base(opts)
    {

    }

    public DbSet<Models.TaskModel> Tasks { get; set; }
}