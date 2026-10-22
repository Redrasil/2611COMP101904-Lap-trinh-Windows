using EduManager.Data;
using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.DAL;
public sealed class MonHocDAL
{
    private readonly EduManagerContext context;
    public MonHocDAL(EduManagerContext context) => this.context = context;
    public List<MonHoc> GetAll() => context.MonHocs.AsNoTracking().OrderBy(x => x.MaMonHoc).ToList();
    public bool Exists(string code) => context.MonHocs.Any(x => x.MaMonHoc == code);
    public void Add(MonHoc item) { context.MonHocs.Add(item); context.SaveChanges(); }
    public void Update(MonHoc item) { context.MonHocs.Update(item); context.SaveChanges(); }
    public void Delete(string code) { var item = context.MonHocs.Find(code); if (item is not null) { context.MonHocs.Remove(item); context.SaveChanges(); } }
}
