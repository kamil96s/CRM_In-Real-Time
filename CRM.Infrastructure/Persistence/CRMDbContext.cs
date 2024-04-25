using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Persistence
{
    public class CRMDbContext : IdentityDbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<CRM.Domain.Entities.CRM> CRMs { get; set; }
        public DbSet<CRM.Domain.Entities.CRMService> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.CRM>()
                .OwnsOne(c => c.ContactDetails);    //wskazujemy, że nasz CRM ma jedną właściwość ContactDetails, dajemy 

            modelBuilder.Entity<Domain.Entities.CRM>()
                .HasMany(c => c.Services)
                .WithOne(s => s.CRM)
                .HasForeignKey(s => s.CRMId);
        }
    }
}
