using Microsoft.EntityFrameworkCore;
using mshop.sharedkernel.coredata.Discounts;

namespace mshop.discounts.infrastructure.Persistence
{
    public class DiscountsDbContext : DbContext
    {
        public DiscountsDbContext()
        {
        }

        public DiscountsDbContext(DbContextOptions<DiscountsDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Host=postgresdb;Port=5432;Database=Discounts;Username=root;Password=password;");

        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discounts");

                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(d => d.Name);

                entity.Property(d => d.MinimumNumberOrdersPerUser);

                entity.Property(d => d.CategoryId);

                entity.Property(d => d.MinimumNumberProductsPerCategory);

                entity.Property(d => d.DiscountType);

                entity.Property(d => d.DiscountPercentValue)
                    .IsRequired();
            });
        }
    }
}
