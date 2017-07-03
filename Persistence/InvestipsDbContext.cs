using investips.Models;
using Microsoft.EntityFrameworkCore;

namespace investips.Persistence
{
    public class InvestipsDbContext :  DbContext
    {
        public DbSet<Porfolio> Porfolios { get; set; }
        public DbSet<Security> Securities { get; set; }
        public InvestipsDbContext(DbContextOptions<InvestipsDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBulder) {
            modelBulder.Entity<PorfolioSecurity>().HasKey(ps =>
                new {ps.PorfolioId, ps.SecurityId});
        }
    }
}