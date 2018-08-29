
namespace schedule.data.erps.his
{
    using System;

    public partial class HIS_NHAPDUOCCHITIET
    {
        public int ID { get; set; }
        public Nullable<int> NhapDuoc_ID { get; set; }
        public Nullable<int> DichVu_Ma { get; set; }
        public string SoLo { get; set; }
        public Nullable<System.DateTime> HanDung { get; set; }
        public string DonVi { get; set; }
        public double DonGiaChiTiet { get; set; }
        public double DonGia { get; set; }
        public int VAT { get; set; }
        public double SoLuongNhap { get; set; }
        public double ThanhTienNhap { get; set; }
        public double SoLuongXuat { get; set; }
        public double ThanhTienXuat { get; set; }
        public double SoLuongKiemKe { get; set; }
        public double ThanhTienKiemKe { get; set; }
        public double SoLuongSuDung { get; set; }
        public double ThanhTienSuDung { get; set; }
        public string NhaCUngCap_Ma { get; set; }
        public string SoDangKy { get; set; }
        public double DonGiaDongY { get; set; }
        public double SoLuongDongY { get; set; }
        public double ThanhTienDongY { get; set; }
        public Nullable<int> BenhNhan_Ma { get; set; }
        public byte DoiTuongBenhNhan_Ma { get; set; }
        public double DonGiaXuat { get; set; }
        public string GhiChu { get; set; }
        public int TrongBaoHiem { get; set; }
    }
}
