# Movies EF Core Project

This is a console-based .NET project that uses **Entity Framework Core** with **PostgreSQL** to manage movies, actors, directors, and genres. The project also includes seed data to quickly populate the database with sample data.

---

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- PostgreSQL installed and running
- A PostgreSQL database that you can connect to (default in the project: `movies_db`)

---

## Steps to Configure the Project

### 1. Create the Database
Open PostgreSQL and run:

```sql
CREATE DATABASE movies_db;

docker run --name movies_db \
-e POSTGRES_USER=postgres \
-e POSTGRES_PASSWORD=2860 \
-e POSTGRES_DB=tododb \
-p 5432:5432 \
-d postgres:16

```

### 2. Create migrations to create tables and insert seed data:
```
dotnet ef migrations add InitialCreate
```
```
dotnet ef database update
```
This command creates a new migration and updates the database with relevant tables and seed data to test the project.