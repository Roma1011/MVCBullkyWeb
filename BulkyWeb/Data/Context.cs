using Bulky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Data;

public class Context:IdentityDbContext
{
    public DbSet<Category> Categories { get; set; }
    public Context(DbContextOptions<Context> option):base(option)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}