namespace StudentReportDemo.Models;
public sealed class SinhVien
{
    public string MaSV { get; init; } = "";
    public string HoTen { get; init; } = "";
    public string MaLop { get; init; } = "";
    public string TenLop { get; init; } = "";
    public double Diem { get; init; }
    public string KetQua => Diem >= 5 ? "Đạt" : "Không đạt";
}
