# MyAcademy Portfolio Project

A database-driven portfolio website and administration panel built with ASP.NET Core MVC, Entity Framework Core and SQL Server.

## Features

- Public portfolio with profile information, education and experience timelines, skill levels, and project cards with category filters.
- Admin screens for managing portfolio content, project categories, social links, and site settings.
- Dashboard with content totals, recent messages and projects, and project counts by category.
- Contact form with server-side validation, a honeypot field, and IP-based rate limiting. The admin inbox supports search, date sorting, read status, and message details.
- PDF résumé download with replacement uploads through **Admin → Site Settings**. Uploads are limited to 10 MB.

## Getting started

Install the .NET 10 SDK and make a SQL Server instance available. Run these commands from the repository root:

```sh
cd MyAcademy_PortfolioProject
dotnet restore
dotnet tool install --global dotnet-ef --version 10.0.13
```

Skip the tool installation if a compatible EF Core CLI is already installed. Create an `appsettings.Development.json` file next to the project file and adjust the connection string for your local instance:

```json
{
  "ConnectionStrings": {
    "PortfolioContext": "Server=localhost;Database=PortfolioDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Apply the migrations and run the app:

```sh
dotnet ef database update -- --environment Development
dotnet run --launch-profile http
```

Open [the portfolio](http://localhost:5183/) or [the admin dashboard](http://localhost:5183/Admin). For a fresh database, add profile information, categories, and other portfolio content through the admin panel.

## Project structure

- `Areas/Admin` contains the admin controllers and Razor views.
- `Controllers`, `Views`, and `ViewComponents` serve the public portfolio.
- `Context`, `Entities`, and `Migrations` define database access, models, and schema changes.
- `wwwroot` contains static files, including portfolio images and résumé PDFs.

The admin area currently has no authentication. Keep it on a trusted development environment until access control is added.
