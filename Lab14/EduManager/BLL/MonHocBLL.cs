using EduManager.DAL;
using EduManager.Models;

namespace EduManager.BLL;
public sealed class MonHocBLL
{
    private readonly MonHocDAL dal;
    public MonHocBLL(MonHocDAL dal) => this.dal = dal;
    public List<MonHoc> GetAll(string keyword = "")
    {
        var all = dal.GetAll();
        return string.IsNullOrWhiteSpace(keyword) ? all : all.Where(x => x.MaMonHoc.Contains(keyword, StringComparison.OrdinalIgnoreCase) || x.TenMonHoc.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public void Add(MonHoc item) { Validate(item); if (dal.Exists(item.MaMonHoc)) throw new InvalidOperationException("Mã môn học đã tồn tại."); dal.Add(item); }
    public void Update(MonHoc item) { Validate(item); if (!dal.Exists(item.MaMonHoc)) throw new InvalidOperationException("Không tìm thấy môn học."); dal.Update(item); }
    public void Delete(string code) { if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Vui lòng chọn môn học."); dal.Delete(code); }
    private static void Validate(MonHoc item)
    {
        if (string.IsNullOrWhiteSpace(item.MaMonHoc)) throw new ArgumentException("Mã môn học không được rỗng.");
        if (string.IsNullOrWhiteSpace(item.TenMonHoc)) throw new ArgumentException("Tên môn học không được rỗng.");
        if (item.SoTinChi is < 1 or > 6) throw new ArgumentException("Số tín chỉ phải từ 1 đến 6.");
    }
}
