
namespace schedule.data.erps.vss
{
    using System;

    public partial class VSS_CHIDINH
    {
        public int ID { get; set; }
        public Nullable<int> CanLamSang_ID { get; set; }
        public Nullable<int> DichVu_Ma { get; set; }
        public Nullable<int> Status { get; set; }
        public string ChiDinh { get; set; }
        public string KetLuan { get; set; }
        public string LoiDan { get; set; }
        public Nullable<int> SoPhieu { get; set; }
        public Nullable<int> TamThu { get; set; }
        public Nullable<int> TrongBaoHiem { get; set; }
        public string Mau_Lan_MTruongXN { get; set; }
        public double DonGia { get; set; }
        public int XaHoiHoa { get; set; }
        public string GhiChu { get; set; }
        public string DanhsachCanBoThuchien { get; set; }
        public Nullable<System.DateTime> NgayThucHien { get; set; }
        public string CanBoThucHien_Ma { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> NgoaiGioHanhChinh { get; set; }
        public int LoaiDichVu { get; set; }
        public Nullable<int> ICD9 { get; set; }
        public string MaMay { get; set; }
    }
}
