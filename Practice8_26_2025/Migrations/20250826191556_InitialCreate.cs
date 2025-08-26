using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Practice8_26_2025_Copy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Processor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RamGB = table.Column<int>(type: "INTEGER", nullable: false),
                    StorageGB = table.Column<int>(type: "INTEGER", nullable: false),
                    StorageType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    OperatingSystem = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    YearManufactured = table.Column<int>(type: "INTEGER", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "Id", "Brand", "DateAdded", "IsActive", "Model", "Notes", "OperatingSystem", "Processor", "PurchasePrice", "RamGB", "StorageGB", "StorageType", "YearManufactured" },
                values: new object[,]
                {
                    { 1, "Dell", new DateTime(2025, 7, 27, 14, 15, 55, 433, DateTimeKind.Local).AddTicks(9438), true, "Latitude 5520", "Corporate laptop - IT Department", "Windows 11 Pro", "Intel Core i7-1185G7", 1299.99m, 16, 512, "SSD", 2021 },
                    { 2, "HP", new DateTime(2025, 7, 12, 14, 15, 55, 433, DateTimeKind.Local).AddTicks(9446), true, "EliteBook 840 G8", "Sales team laptop", "Windows 10 Pro", "Intel Core i5-1135G7", 899.99m, 8, 256, "SSD", 2020 },
                    { 3, "Apple", new DateTime(2025, 6, 27, 14, 15, 55, 433, DateTimeKind.Local).AddTicks(9450), true, "MacBook Pro 13", "Design team - Creative Suite", "macOS Monterey", "Apple M1", 1499.99m, 16, 512, "SSD", 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
