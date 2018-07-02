
namespace schedule.data.erps.vss
{
    using System;

    public partial class VSS_DONTHUOC
    {
        public int ID { get; set; }
        public Nullable<int> PhongBan_Ma { get; set; }
        public Nullable<int> BenhNhan_Ma { get; set; }
        public string CanBo_Ma { get; set; }
        public Nullable<int> Status { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> PhongBanXuat_Ma { get; set; }
        public Nullable<int> PhanLoaiDichVu { get; set; }
        public Nullable<System.DateTime> NgayKeDon { get; set; }
        public Nullable<int> KieuDon { get; set; }
        public Nullable<int> LoaiDuoc { get; set; }
        public Nullable<int> SoPhieuLinh { get; set; }
        public Nullable<int> SoVaoVien { get; set; }
    }
}
