using investips.Models;
using Microsoft.EntityFrameworkCore;

namespace investips.Persistence
{
    public class InvestipsDbContext :  DbContext
    {
        public InvestipsDbContext(DbContextOptions<InvestipsDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Porfolio> Porfolios { get; set; }
        public DbSet<Security> Securities { get; set; }
    }
}