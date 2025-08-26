using Microsoft.EntityFrameworkCore;
using Practice8_26_2025_Copy.Models;

namespace Practice8_26_2025_Copy.Data
{
    public class ComputerDbContext : DbContext
    {
        public ComputerDbContext(DbContextOptions<ComputerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Computer> Computers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed some sample data
            modelBuilder.Entity<Computer>().HasData(
                new Computer
                {
                    Id = 1,
                    Brand = "Dell",
                    Model = "Latitude 5520",
                    Processor = "Intel Core i7-1185G7",
                    RamGB = 16,
                    StorageGB = 512,
                    StorageType = "SSD",
                    OperatingSystem = "Windows 11 Pro",
                    YearManufactured = 2021,
                    PurchasePrice = 1299.99m,
                    Notes = "Corporate laptop - IT Department",
                    DateAdded = DateTime.Now.AddDays(-30),
                    IsActive = true
                },
                new Computer
                {
                    Id = 2,
                    Brand = "HP",
                    Model = "EliteBook 840 G8",
                    Processor = "Intel Core i5-1135G7",
                    RamGB = 8,
                    StorageGB = 256,
                    StorageType = "SSD",
                    OperatingSystem = "Windows 10 Pro",
                    YearManufactured = 2020,
                    PurchasePrice = 899.99m,
                    Notes = "Sales team laptop",
                    DateAdded = DateTime.Now.AddDays(-45),
                    IsActive = true
                },
                new Computer
                {
                    Id = 3,
                    Brand = "Apple",
                    Model = "MacBook Pro 13",
                    Processor = "Apple M1",
                    RamGB = 16,
                    StorageGB = 512,
                    StorageType = "SSD",
                    OperatingSystem = "macOS Monterey",
                    YearManufactured = 2021,
                    PurchasePrice = 1499.99m,
                    Notes = "Design team - Creative Suite",
                    DateAdded = DateTime.Now.AddDays(-60),
                    IsActive = true
                }
            );
        }
    }
} 