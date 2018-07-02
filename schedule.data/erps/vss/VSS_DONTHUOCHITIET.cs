
namespace schedule.data.erps.vss
{
    using System;

    public partial class VSS_DONTHUOCHITIET
    {
        public int ID { get; set; }
        public Nullable<int> DonThuoc_ID { get; set; }
        public Nullable<int> DichVu_Ma { get; set; }
        public string DonVi { get; set; }
        public double DonGia { get; set; }
        public string SoLo { get; set; }
        public double SoLuong { get; set; }
        public double ThanhTien { get; set; }
        public double TienBenhNhan { get; set; }
        public double TienBaoHiem { get; set; }
        public double TienChenhLenh { get; set; }
        public int TrongBaoHiem { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public string DuongDung { get; set; }
        public string MoiLan { get; set; }
        public string DonViUong { get; set; }
        public string SoLan { get; set; }
        public string LieuLuong { get; set; }
        public string NhaCungCap_Ma { get; set; }
        public int SoPhieuLinh { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> ChiDinh_ID { get; set; }
        public string CanBo_Ma { get; set; }
        public string DanhSachCanBoThucHien { get; set; }
        public Nullable<int> PhongBan_Ma { get; set; }
        public int BenhNhanKhamBenh_ID { get; set; }
        public byte Loai { get; set; }
        public int ThanhToan { get; set; }
        public int MienGiam { get; set; }
        public string GhiChu { get; set; }
        public int PhongBanTongKet_Ma { get; set; }
        public Nullable<int> PhongBanXuat_Ma { get; set; }
        public double TyLeThanhToan { get; set; }
        public int XaHoiHoa { get; set; }
        public double SoLuongChiTiet { get; set; }
        public Nullable<int> DonThuocChiTietAttach_ID { get; set; }
        public Nullable<System.DateTime> HanDung { get; set; }
        public int LoaiDichVu { get; set; }
    }
}
