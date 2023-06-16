using LearnEF.Seeding;
using Microsoft.EntityFrameworkCore;

namespace LearnEF.Models
{
	public class ProductContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(
				"Data Source=SF-CPU-523;Initial Catalog=Product_Management;User ID=sa;Password=Abhi@15042002;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

			}

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CategorySeed());

			modelBuilder.ApplyConfiguration(new ProductSeed());
		}


	}
}