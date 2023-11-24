# Schoolme

### Migrations

The app uses multiple schemas of single database. Each schema is built as separate DbContext, with own migration history.

#### Outbox scheme

`dotnet ef migrations add "Init" -o Infrastructure/Outbox/Migrations -p Schoolme/Schoolme.csproj -c OutboxDbContext`
`dotnet ef database update -p Schoolme/Schoolme.csproj -c OutboxDbContext`

#### Students scheme

`dotnet ef migrations add "Init" -o Infrastructure/Students/Database/Migrations -p Schoolme/Schoolme.csproj -c StudentsDbContext`
`dotnet ef database update -p Schoolme/Schoolme.csproj -c StudentsDbContext`