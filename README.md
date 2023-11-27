## Entity Framework Core 8 Kurulum Linkleri

**1- Entity Framework Core Tools**

- dotnet tool uninstall --global dotnet-ef
- dotnet tool install --global dotnet-ef --version 8.0.0

**2- Entity Framework Core Packages**

- dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0
- dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.0

- dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0

**3- Proje Referansının Eklenmesi**

- cd StoreApp.Web
- dotnet add reference ../StoreApp.Data/StoreApp.Data.csproj