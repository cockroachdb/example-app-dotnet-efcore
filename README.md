# example-app-dotnet-efcore

A simple example of using CockroachDB with EntityFramework Core and the Npgsql driver.

### Preparation

Add the database URL to the environment variable

``` sh
export DATABASE_URL="Host=localhost;Port=26257;Database=defaultdb;Username=root"
```

Run migrations

``` sh
dotnet tool install --global dotnet-ef
dotnet ef database update
```

Run app

``` sh
dotnet run
```