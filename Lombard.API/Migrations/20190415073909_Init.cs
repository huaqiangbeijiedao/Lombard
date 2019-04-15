using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lombard.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsHistory_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[] { 1, "Opona", 10.0, 30 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[] { 2, "Felga", 50.0, 5 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[] { 3, "Klucz", 3.0, 100 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[] { 4, "Sruba", 1.0, 500 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "TransactionDate", "TransactionType" },
                values: new object[] { 1, new DateTime(2019, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "TransactionDate", "TransactionType" },
                values: new object[] { 2, new DateTime(2019, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "ProductsHistory",
                columns: new[] { "Id", "Name", "Price", "Quantity", "TransactionId" },
                values: new object[] { 1, "Opona", 10.0, 35, 1 });

            migrationBuilder.InsertData(
                table: "ProductsHistory",
                columns: new[] { "Id", "Name", "Price", "Quantity", "TransactionId" },
                values: new object[] { 2, "Felga", 50.0, 10, 1 });

            migrationBuilder.InsertData(
                table: "ProductsHistory",
                columns: new[] { "Id", "Name", "Price", "Quantity", "TransactionId" },
                values: new object[] { 3, "Klucz", 3.0, 105, 1 });

            migrationBuilder.InsertData(
                table: "ProductsHistory",
                columns: new[] { "Id", "Name", "Price", "Quantity", "TransactionId" },
                values: new object[] { 4, "Sruba", 1.0, 510, 1 });

            migrationBuilder.InsertData(
                table: "ProductsHistory",
                columns: new[] { "Id", "Name", "Price", "Quantity", "TransactionId" },
                values: new object[] { 5, "Opona", 12.0, 5, 2 });

            migrationBuilder.InsertData(
                table: "ProductsHistory",
                columns: new[] { "Id", "Name", "Price", "Quantity", "TransactionId" },
                values: new object[] { 6, "Felga", 51.0, 5, 2 });

            migrationBuilder.InsertData(
                table: "ProductsHistory",
                columns: new[] { "Id", "Name", "Price", "Quantity", "TransactionId" },
                values: new object[] { 7, "Klucz", 4.0, 5, 2 });

            migrationBuilder.InsertData(
                table: "ProductsHistory",
                columns: new[] { "Id", "Name", "Price", "Quantity", "TransactionId" },
                values: new object[] { 8, "Sruba", 1.25, 10, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_TransactionId",
                table: "ProductsHistory",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductsHistory");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
