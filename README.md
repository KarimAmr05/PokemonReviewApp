# PokemonReviewApp

production-oriented ASP.NET Core Web API sample for managing Pokemon, Owners, Categories, Reviews, and Reviewers.

## Overview

PokemonReviewApp is a demonstration Web API built on .NET 10 and Entity Framework Core. It implements common domain entities and relationships (Pokemon, Owners, Categories, Reviews, Reviewers) and includes migrations to keep the database schema in sync with the model.

**Key technologies**
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core (Code First migrations)
- SQL Server

## Features
- RESTful API endpoints for core CRUD operations
- EF Core migrations with a sample rename migration (Pokemons → Pokemon)
- Repository pattern and AutoMapper mapping profiles

## Prerequisites
- .NET 10 SDK (installed)
- SQL Server instance (local or remote)
- Optional: Visual Studio 2022/2026 or Visual Studio Code

## Quick start
1. Clone the repository and open the solution:

   ```bash
   git clone https://github.com/KarimAmr05/PokemonReviewApp.git
   cd PokemonReviewApp
   ```

2. Configure the database connection:

   - Open `PokemonReviewApp/appsettings.json` and update `ConnectionStrings:DefaultConnection` to point at your SQL Server instance.

3. Apply Entity Framework migrations to ensure the database schema matches the model:

   - Using the Package Manager Console (Visual Studio):

     ```powershell
     Update-Database
     ```

   - Using the dotnet CLI:

     ```bash
     dotnet ef database update --project PokemonReviewApp
     ```

   > **Note**: The repository already contains a migration `RenamePokemonsToPokemon` which renames the `Pokemons` table to `Pokemon`. If you have not generated that migration locally and want to create or regenerate it, run (optional):
   >
   > - PMC: `Add-Migration RenamePokemonsToPokemon`
   > - CLI: `dotnet ef migrations add RenamePokemonsToPokemon --project PokemonReviewApp`
   >
   > After adding a migration, run `Update-Database` to apply it.

4. Run the API:

   - Visual Studio: Run the project or press F5.
   - CLI: `dotnet run --project PokemonReviewApp`

   The API will be available at the configured URL (see launch settings).

## Common issue: "Invalid object name 'Pokemon'"
If you encounter a SqlException complaining that the object `Pokemon` does not exist, that indicates your database schema is out of sync with the model. Remedies:
- Run `Update-Database` to apply pending migrations (this will execute the rename migration if present).
- Manually rename the table in the database from `Pokemons` to `Pokemon` if you prefer not to run migrations.
- Confirm the connection string targets the database instance where your migrations were applied.

## API examples
- `GET /api/pokemon` — list all pokemon
- `GET /api/pokemon/{id}` — retrieve a pokemon by id
- `POST /api/pokemon` — create a new pokemon
- `PUT /api/pokemon/{id}` — update an existing pokemon
- `DELETE /api/pokemon/{id}` — remove a pokemon

Refer to the Controllers in the `PokemonReviewApp/Controllers` folder for full route definitions and request/response models.

## Development
- Follow established style and patterns in the repository.
- Add migrations when changing model classes:
  - `dotnet ef migrations add <Name> --project PokemonReviewApp`
  - `dotnet ef database update --project PokemonReviewApp`

## Contributing
Contributions and pull requests are welcome. Please open an issue to discuss larger changes before submitting a PR.

## License
This project is provided for educational and demonstration purposes. Check the repository root for any license file or add one if you intend to publish it publicly.