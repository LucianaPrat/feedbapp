
#ejecutar las migraciones en la base de datos
dotnet ef database update --project Dominio --startup-project .\Feedbapp
#crear la migracion
dotnet ef migrations add AddAdminsTable --project Dominio --startup-project .\Feedbapp