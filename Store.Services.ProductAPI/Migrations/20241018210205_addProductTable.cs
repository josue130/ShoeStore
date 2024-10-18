using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class addProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2bb2d3cd-c94d-4085-9bfa-c2b5739b57b1"), "Tennis", "Pickleball shoes", "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/e1e4ff2e-7111-419d-8165-7874d8e4846b/M+ZOOM+CHALLENGE+PB.png", "Nike Zoom Challenge", 120.0 },
                    { new Guid("9175c962-250a-40cd-aa3d-832d9e555b6d"), "Tennis", "Hard Court Tennis Shoes", "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/533dfb67-8c51-4ace-ac1e-ba51f1ac7766/W+ZOOM+GP+CHALLENGE+1+HC.png", "Nike Zoom GP Challenge 1", 160.0 },
                    { new Guid("bd2c9258-ee9c-4f8b-83ae-5a3e6e00cb87"), "Tennis", "Hard Court Tennis Shoes", "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/733b75de-1ebc-4842-baad-2035b1d5e4e2/M+NIKE+ZOOM+VAPOR+11+HC.png", "NikeCourt Air Zoom Vapor 11", 170.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
