using LearnEF.Models;
using System.Data.Common;

namespace LearnEF
{
	internal class Program
	{
		static void Main(string[] args)
		{

			

			ProductContext db = new();

			db.SaveChangesFailed += Db_SaveChangesFailed;
			db.SavingChanges += Db_SavingChanges;
			bool exit = true;
			while (exit)
			{
				Console.WriteLine("What do you want!");
				Console.WriteLine("1. see product!");
				Console.WriteLine("2. see category!");
				Console.WriteLine("3. update product!");
				Console.WriteLine("4. delete product!");
				Console.WriteLine("5. Add Category!");
				Console.WriteLine("6. clear console!");
				Console.WriteLine("7. exit!");


				int test = Convert.ToInt32(Console.ReadLine());

				switch (test)
				{
					case 0:
						Console.WriteLine("Fuck!");
						break;
					case 1:
						ShowProducts(db);
						break;
					case 2:
						ShowCategories(db);
						break;
					case 3:
						UpdateProduct(db);
						break;
					case 4:
						RemoveProduct(db);
						break;
					case 5:
						AddCategory(db);
						break;
					case 6:
						Console.Clear();
						break;
					case 7:
						exit = false;
						break;
					default:
						Console.WriteLine("Fucker enter valid value!");
						break;
				}


			}

			db.SaveChangesFailed -= Db_SaveChangesFailed;
			db.SavingChanges -= Db_SavingChanges;

		}

		private static void UpdateProduct(ProductContext db)
		{
			ShowProducts(db);

			Console.Write("\nEnter the product id which you want to update! :: ");
			int id = Convert.ToInt32(Console.ReadLine());

			if (db.Products.Any(x => x.ID == id))
			{
				Console.WriteLine("Which thing you want to update!");
				Console.WriteLine("1. name");
				Console.WriteLine("2. price");
				Console.WriteLine("3. category");

				int test = Convert.ToInt32(Console.ReadLine());

				if (test == 1)
				{
					Console.Write("Enter the name : ");
					string x = Console.ReadLine();

					db.Products.FirstOrDefault(x => x.ID == id).Name = x;
					Console.WriteLine("Product Update");

				}
				else if (test == 2)
				{
					Console.Write("Enter the price : ");
					int x = Convert.ToInt32(Console.ReadLine());

					db.Products.FirstOrDefault(x => x.ID == id).Price = x;
					Console.WriteLine("Product Update");

				}
				else if (test == 3)
				{
					Console.Write("Enter the Category id: ");
					int x = Convert.ToInt32(Console.ReadLine());

					db.Products.FirstOrDefault(x => x.ID == id).CategoryID = x;

					Console.WriteLine("Product Update");
				}
				else
				{
					Console.WriteLine("Wrong option ");
				}

				db.SaveChanges();
			}
			else
			{
				Console.WriteLine("product id does not exits");
			}

			ShowProducts(db);
		}

		private static void Db_SavingChanges(object? sender, Microsoft.EntityFrameworkCore.SavingChangesEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Changes Started!");
			Console.ResetColor();
		}

		private static void Db_SaveChangesFailed(object? sender, Microsoft.EntityFrameworkCore.SaveChangesFailedEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Changes failed");
			Console.ResetColor();
		}

		public static void ShowProducts(ProductContext db)
		{
			if (db.Products.Count() != 0)
			{
				foreach (var item in db.Products)
				{
					Console.WriteLine($"Product ID {item.ID}  \t Product Name : {item.Name} \t Category : {item.CategoryID} \t price : {item.Price}");
				}
			}
			else
			{
				Console.WriteLine("No Product is available");
			}

		}

		public static void ShowCategories(ProductContext db)
		{
			if (db.Categories.Count() != 0)
			{
				foreach (var item in db.Categories)
				{
					Console.WriteLine($"Category ID {item.CategoryId}  \t CategoryName : {item.CategoryName}");
				}
			}
			else
			{
				Console.WriteLine("No Category is available");
			}

		}

		public static void AddCategory(ProductContext db)
		{

			Console.Write("Category Name :");

			string categoryName = Console.ReadLine();

			db.Categories.Add(new Category() { CategoryName = categoryName });

			db.SaveChanges();

		}

		public static void AddProduct(ProductContext db)
		{
			Console.Write("product Name : ");

			string productName = Console.ReadLine();

			Console.Write("Enter Price :");

			int price = Convert.ToInt32(Console.ReadLine());

			ShowCategories(db);

			Console.WriteLine("Enter Categories : ");

			int categoryID = Convert.ToInt32(Console.ReadLine());

			db.Products.Add(new Product() { Price = price, CategoryID = categoryID, Name = productName });

			try
			{
				db.SaveChanges();
				Console.WriteLine("Product Added!");
			}
			catch (Exception)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Product is not added!");
				Console.WriteLine("foreign key is not matched!");
				//Console.WriteLine(ex.InnerException.Message);
				Console.ResetColor();
			}
		}

		public static void RemoveProduct(ProductContext db)
		{
			ShowProducts(db);

			Console.WriteLine("Enter id which are you want to delete!");
			int id = Convert.ToInt32(Console.ReadLine());

			var product = db.Products.Where(x => x.ID == id).ToList();

			if (product.SingleOrDefault() != null)
			{
				db.Products.Remove(product.SingleOrDefault());
				db.SaveChanges();
				Console.WriteLine("Data Deleted!");
			}
			else
			{
				Console.WriteLine("Wrong value");
			}
		}

	}
}