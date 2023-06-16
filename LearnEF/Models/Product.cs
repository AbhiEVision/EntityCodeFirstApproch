using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnEF.Models
{
	public class Product
	{
		[Key]
		[Display(Name = "ProductID")]

		public int ID { get; set; }

		[Required]
		[Display(Name = "ProductName")]
		public string Name { get; set; }

		[Required]
		[DefaultValue(100)]
		public int Price { get; set; }

		[Required]
		[ForeignKey("CategoryID")]
		public int CategoryID { get; set; }
		public Category category { get; set; }

	}
}