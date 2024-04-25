using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LR12_Chupyna_ASP_402
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
