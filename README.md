
## Bootstrap ile Asp.NET Uygulamasına Tema Uygulama

 **1- Libman Kurulumu**

- dotnet tool list -g
- dotnet tool uninstall --global Microsoft.Web.LibraryManager.Cli
- dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.1.175

**2- Libman Configuration File**
- cd storeApp.Web
- libman init -p cdnjs

**3- Kütüphane Kurulumu**
- libman install bootstrap@5.3.2 -d wwwroot/lib/bootstrap

**4- Css Kütaphanesinin Dahil Edilmesi**
-  \<link  href="/lib/bootstrap/css/bootstrap.min.css"  rel="stylesheet"  />