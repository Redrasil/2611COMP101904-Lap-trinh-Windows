using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.Data;
public sealed class EduManagerContext : DbContext
{
    public DbSet<MonHoc> MonHocs => Set<MonHoc>();
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=.\\SQLEXPRESS;Database=EduManagerDB;Integrated Security=True;TrustServerCertificate=True;");
    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<MonHoc>().ToTable("MONHOC");
        model.Entity<MonHoc>().HasKey(x => x.MaMonHoc);
        model.Entity<MonHoc>().Property(x => x.MaMonHoc).HasMaxLength(10).IsRequired();
        model.Entity<MonHoc>().Property(x => x.TenMonHoc).HasMaxLength(100).IsRequired();
        model.Entity<MonHoc>().ToTable("MONHOC", table => table.HasCheckConstraint("CK_MONHOC_SoTinChi", "[SoTinChi] BETWEEN 1 AND 6"));
    }
}
