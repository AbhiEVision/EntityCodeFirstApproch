﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearnEF.Migrations
{
	/// <inheritdoc />
	public partial class Initial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					CategoryId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.CategoryId);
				});

			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Price = table.Column<int>(type: "int", nullable: false),
					CategoryID = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.ID);
					table.ForeignKey(
						name: "FK_Products_Categories_CategoryID",
						column: x => x.CategoryID,
						principalTable: "Categories",
						principalColumn: "CategoryId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Categories",
				columns: new[] { "CategoryId", "CategoryName" },
				values: new object[,]
				{
					{ 1, "Health" },
					{ 2, "Beauty" }
				});

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "ID", "CategoryID", "Name", "Price" },
				values: new object[,]
				{
					{ 1001, 1, "Product1", 100001 },
					{ 1002, 2, "Product2", 200001 },
					{ 1003, 1, "Product3", 3001 }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Products_CategoryID",
				table: "Products",
				column: "CategoryID");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Products");

			migrationBuilder.DropTable(
				name: "Categories");
		}
	}
}
