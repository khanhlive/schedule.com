
namespace schedule.data.erps.vss
{
    using System;

    public partial class VSS_CANLAMSANG
    {
        public int ID { get; set; }
        public Nullable<int> BenhNhan_Ma { get; set; }
        public string CanBo_Ma { get; set; }
        public Nullable<int> PhongBan_Ma { get; set; }
        public Nullable<int> PhongBanThucHien_Ma { get; set; }
        public Nullable<System.DateTime> NgayThang { get; set; }
        public string CanBoThucHien_Ma { get; set; }
        public Nullable<System.DateTime> NgayThucHien { get; set; }
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string DanhsachCanboThuchien { get; set; }
        public byte Status { get; set; }
        public Nullable<int> STT { get; set; }
        public string BenhPham { get; set; }
        public string TrangThaiBenhPham { get; set; }
        public Nullable<System.DateTime> ThoiGianLayMau { get; set; }
        public Nullable<System.DateTime> ThoiGianNhanMau { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayNhanKetQua { get; set; }
        public bool CapCuu { get; set; }
        public Nullable<int> IDBB { get; set; }
        public string ChanDoan { get; set; }
        public string ICD_Ma { get; set; }
        public Nullable<bool> TrangThaiBenhNhan { get; set; }
    }
}
