using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationDatabase : DbContext
{
    public ApplicationDatabase(DbContextOptions<ApplicationDatabase> opt) : base(opt)
    {
    }

    public virtual DbSet<User> Users => Set<User>();
}
