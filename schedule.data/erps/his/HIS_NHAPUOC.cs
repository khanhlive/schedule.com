
namespace schedule.data.erps.his
{
    using System;

    public partial class HIS_NHAPUOC
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public string SoChungTu { get; set; }
        public Nullable<int> PhongBan_Ma { get; set; }
        public string TenNguoiCungCap { get; set; }
        public string NhaCungCap_Ma { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> PhanLoai { get; set; }
        public Nullable<int> PhongBanNhapXuat_Ma { get; set; }
        public Nullable<int> KieuDon { get; set; }
        public Nullable<int> BenhNhan_Ma { get; set; }
        public string MaXP { get; set; }
        public Nullable<int> XuatTD { get; set; }
        public string CanBo_Ma { get; set; }
        public Nullable<int> SoPhieuLinh { get; set; }
        public string DiaChi { get; set; }
        public byte DoiTuongBenhNhan_Ma { get; set; }
        public int Mien { get; set; }
        public int TraDuoc_KieuDon { get; set; }
        public Nullable<System.DateTime> NgayTT { get; set; }
        public Nullable<System.DateTime> NgayNhap_NVL { get; set; }
        public Nullable<int> IDSXThuoc { get; set; }
        public Nullable<int> TangGiaSX { get; set; }
        public string SoPhieu { get; set; }
        public Nullable<int> LoaiTang { get; set; }
    }
}
