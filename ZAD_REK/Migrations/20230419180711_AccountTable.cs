using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD_REK.Migrations
{
    public partial class AccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefrestTokenExp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdUser);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7314), new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7352), new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7355), new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7356) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5452), new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5491), new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5493) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5495), new DateTime(2023, 4, 19, 18, 59, 52, 623, DateTimeKind.Local).AddTicks(5497) });
        }
    }
}
