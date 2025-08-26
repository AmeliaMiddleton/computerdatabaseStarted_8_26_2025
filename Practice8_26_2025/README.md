# Computer Inventory System

A web application built with ASP.NET Core MVC for managing computer inventory using SQLite database.

## Features

- **Computer Management**: Add, edit, view, and delete computer records
- **Search & Sort**: Search computers by brand, model, or processor with sorting capabilities
- **Comprehensive Details**: Track brand, model, processor, RAM, storage, OS, year, price, and notes
- **Responsive Design**: Modern Bootstrap-based UI that works on all devices
- **Data Validation**: Client and server-side validation for data integrity

## Technology Stack

- **Backend**: ASP.NET Core 8.0 MVC
- **Database**: SQLite with Entity Framework Core
- **Frontend**: Bootstrap 5, jQuery, Razor Views
- **Validation**: Data Annotations with client-side validation

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code

### Installation

1. Clone or download the project
2. Navigate to the project directory
3. Restore NuGet packages:
   ```
   dotnet restore
   ```
4. Install client-side libraries:
   ```
   dotnet tool install -g Microsoft.Web.LibraryManager.Cli
   libman restore
   ```
5. Create and update the database:
   ```
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
6. Run the application:
   ```
   dotnet run
   ```

### Database Setup

The application uses SQLite with Entity Framework Core. The database file (`computers.db`) will be created automatically when you run the first migration.

### Sample Data

The application comes with sample computer data including:
- Dell Latitude 5520 (IT Department)
- HP EliteBook 840 G8 (Sales Team)
- Apple MacBook Pro 13 (Design Team)

## Usage

1. **Home Page**: Dashboard showing total computer count and recently added computers
2. **Computers List**: View all computers with search and sort functionality
3. **Add Computer**: Form to add new computers to the inventory
4. **Computer Details**: Comprehensive view of computer specifications
5. **Edit Computer**: Update existing computer information
6. **Delete Computer**: Mark computers as inactive (soft delete)

## Project Structure

```
Practice8_26_2025/
├── Controllers/          # MVC Controllers
├── Data/                # Database context and models
├── Models/              # Domain models
├── Views/               # Razor views
├── wwwroot/             # Static files (CSS, JS, images)
└── Program.cs           # Application entry point
```

## Database Schema

The `Computer` entity includes:
- Basic Info: Brand, Model, Processor
- Specifications: RAM, Storage, Storage Type, OS
- Metadata: Year Manufactured, Purchase Price, Notes
- System Fields: ID, Date Added, Active Status

## Contributing

Feel free to submit issues, feature requests, or pull requests to improve the application.

## License

This project is open source and available under the MIT License. 