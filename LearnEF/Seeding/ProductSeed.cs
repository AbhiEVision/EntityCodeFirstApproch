using LearnEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnEF.Seeding
{
	internal class ProductSeed : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{

			builder.ToTable("Product");

			builder.HasData
				(
					new Product() { Name = "Product1", ID = 1001, CategoryID = 1, Price = 100001 },
					new Product() { Name = "Product3", ID = 1003, CategoryID = 1, Price = 3001 },
					new Product() { Name = "Product2", ID = 1002, CategoryID = 2, Price = 200001 }
				);
		}
	}
}
