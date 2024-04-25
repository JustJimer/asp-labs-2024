using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LR12_Chupyna_ASP_402
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
