using Microsoft.EntityFrameworkCore;

namespace gruppÖvning_TODO;

public class TodoDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options) { }
}
