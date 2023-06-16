using LearnEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnEF.Seeding
{
	internal class CategorySeed : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);

			

			builder.HasData
				(
					new Category() { CategoryId = 1, CategoryName = "Health" },
					new Category() { CategoryId = 2, CategoryName = "Beauty" }
				);
		}
	}



}
