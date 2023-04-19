using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD_REK.Migrations
{
    public partial class TabelaDanezautonumerowaniem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "CreatedAt", "EditedAt", "Price", "ProductDesc", "ProductName" },
                values: new object[] { 1, new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5452), new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5485), 1111.0, "Desc1", "Prod1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "CreatedAt", "EditedAt", "Price", "ProductDesc", "ProductName" },
                values: new object[] { 2, new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5491), new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5493), 2222.0, null, "Prod2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "CreatedAt", "EditedAt", "Price", "ProductDesc", "ProductName" },
                values: new object[] { 3, new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5495), new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5497), 3333.0, "Desc3", "Prod3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
