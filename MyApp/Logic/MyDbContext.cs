using Microsoft.EntityFrameworkCore;
using MyApp.Logic.Models;


namespace MyApp.Logic;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options) { }

    public DbSet<Athlete> Athlete { get; set; }


}

