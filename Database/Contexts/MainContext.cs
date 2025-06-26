using Microsoft.EntityFrameworkCore;
using CleanArchPOC.Database.Models;

namespace CleanArchPOC.Database.Contexts;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
}