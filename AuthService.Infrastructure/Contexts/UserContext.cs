using AuthService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Contexts;

//работа с пользователями бд

public sealed class UserContext : DbContext
{
    
    public DbSet<User> Users => Set<User>();
    public UserContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }

    
}