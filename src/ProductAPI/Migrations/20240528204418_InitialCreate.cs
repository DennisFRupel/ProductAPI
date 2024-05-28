using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1L, "Celular", 2999.99m, 50 },
                    { 2L, "Notebook", 4999.99m, 30 },
                    { 3L, "Tablet", 1999.99m, 20 },
                    { 4L, "Relógio Inteligente", 999.99m, 15 },
                    { 5L, "Fone de Ouvido", 299.99m, 100 },
                    { 6L, "Caixa de Som Bluetooth", 499.99m, 70 },
                    { 7L, "Teclado", 149.99m, 40 },
                    { 8L, "Mouse", 99.99m, 80 },
                    { 9L, "Monitor", 899.99m, 25 },
                    { 10L, "HD Externo", 399.99m, 60 }
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
