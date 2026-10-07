namespace ShopManagerMini.Models
{
    public class Customer
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
        public string LoaiKH { get; set; }

        public Customer() { }

        public Customer(string maKH, string tenKH, string soDienThoai, string loaiKH)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SoDienThoai = soDienThoai;
            LoaiKH = loaiKH;
        }

        public Customer Clone()
        {
            return new Customer(MaKH, TenKH, SoDienThoai, LoaiKH);
        }
    }
}
