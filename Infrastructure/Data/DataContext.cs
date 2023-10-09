using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options){}
    public DbSet<Category> Categories { get; set; }
    public DbSet<TodoTask> Tasks { get; set; } 
}
