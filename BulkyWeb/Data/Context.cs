using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Data;

public class Context:DbContext
{
    public DbSet<Category> Categories { get; set; }

    public Context(DbContextOptions<Context> option):base(option)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name="Action",
                DisplayOrder = 1
            },
            new Category
            {
                Id = 2,
                Name="SciFi",
                DisplayOrder = 2
            },
            new Category
            {
                Id = 3,
                Name="History",
                DisplayOrder = 2
            }
            );
        base.OnModelCreating(modelBuilder);
    }
}