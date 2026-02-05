# Movies EF Core Project

Detta är ett konsolbaserat .NET-projekt som använder **Entity Framework Core** med **PostgreSQL** för att hantera filmer, skådespelare, regissörer och genrer. Projektet innehåller även seed-data för att snabbt fylla databasen med exempeldata.

---

## Förutsättningar

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- PostgreSQL installerad och körande
- En PostgreSQL-databas som du kan ansluta till (standard i projektet: `movies_db`)

---

## Steg för att konfigurera projektet

### 1. Skapa databasen
Öppna PostgreSQL och kör:

```sql
CREATE DATABASE movies_db;

docker run --name movies_db \
-e POSTGRES_USER=postgres \
-e POSTGRES_PASSWORD=2860 \
-e POSTGRES_DB=tododb \
-p 5432:5432 \
-d postgres:16
```

### 2. Skapa migration för att skapa tabellerna och injicera seed-data
```
dotnet ef migrations add InitialCreate
```
```
dotnet ef database update
```

Det här kommandot skapar en ny migration och uppdaterar databasen med relevanta tabeller
och seed-data för att testa projektet.