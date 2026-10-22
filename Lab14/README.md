# Lab 14 - Entity Framework Core và mô hình ba lớp

`EduManager` tách `GUI`, `BLL`, `DAL`, `Data` và `Models`. Chạy `Database.sql` trên SQL Server, chỉnh connection string trong `Data\EduManagerContext.cs` nếu cần, rồi chạy project bằng Visual Studio 2022/.NET 8. GUI không chứa SQL; BLL validation; DAL dùng EF Core.
