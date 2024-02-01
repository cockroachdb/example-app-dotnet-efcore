# example-app-dotnet-efcore

A simple example of using CockroachDB with EntityFramework Core and the Npgsql driver.

### Preparation

Add the database URL to the environment variable

``` sh
# For a local, insecure database:
export DATABASE_URL="Host=localhost;Port=26257;Database=defaultdb;Username=root"

# For a remote, secure database:
export DATABASE_URL="Server=HOST;Port=26257;Database=defaultdb;Userid=USER;Password=PASSWORD;SslMode=Require;"
```

Run migrations

``` sh
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Run app

``` sh
dotnet run
```