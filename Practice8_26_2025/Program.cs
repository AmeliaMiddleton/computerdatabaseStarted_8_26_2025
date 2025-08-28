using Microsoft.EntityFrameworkCore;
using Practice8_26_2025_Copy.Data;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add SQLite database context
builder.Services.AddDbContext<ComputerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Ensure database is created and migrated
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ComputerDbContext>();
    try
    {
        // This will create the database if it doesn't exist and apply migrations
        context.Database.Migrate();
        
        // Seed data if the Computers table is empty
        if (!context.Computers.Any())
        {
            // Seed initial data
            context.Computers.AddRange(
                new Practice8_26_2025_Copy.Models.Computer
                {
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
                new Practice8_26_2025_Copy.Models.Computer
                {
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
                new Practice8_26_2025_Copy.Models.Computer
                {
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
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        // Log the error but don't crash the app
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
