# Migration notes

Visual Studio console:

```
// -o for changing the output desitination path. 
Add-Migration Initial -o "Data\AptMgmtMigrations"
Update-Database
```

.NET Core CLI:

```
dotnet ef migrations add Initial -o Data/AptMgmtMigrations
dofnet ef database update
```
