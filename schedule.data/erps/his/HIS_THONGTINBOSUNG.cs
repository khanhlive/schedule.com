
namespace schedule.data.erps.his
{
    using System;

    public partial class HIS_THONGTINBOSUNG
    {
        public int ID { get; set; }
        public int BenhNhan_ID { get; set; }
        public string NgheNghiep { get; set; }
        public string NhanThan { get; set; }
        public string NoiLamViec { get; set; }
        public string SoKhaiSinh { get; set; }
        public string Tinh_Ma { get; set; }
        public string Huyen_Ma { get; set; }
        public string Xa_Ma { get; set; }
        public string DanToc_Ma { get; set; }
        public string NgoaiKieu { get; set; }
        public string SoDienThoai { get; set; }
        public string SoDienThoaiNhanTin { get; set; }
        public string CMND_So { get; set; }
        public Nullable<System.DateTime> CMND_NgayCap { get; set; }
        public string CMND_NoiCap { get; set; }
        public string NgheNghiep_Ma { get; set; }
        public string ThonPho { get; set; }
        public Nullable<int> ID_CB { get; set; }
        public Nullable<int> ID_CV { get; set; }
        public Nullable<int> ThangTheoDoi { get; set; }
        public Nullable<int> TienSuDieuTri { get; set; }
        public Nullable<int> TinhTrangH { get; set; }
        public Nullable<int> ChanDoanLao { get; set; }
        public Nullable<int> So_eTBM { get; set; }
        public Nullable<int> DoiTuongLao { get; set; }
        public string DoiTuongLaoKhac { get; set; }
        public string DuongDanAnh { get; set; }
    }
}
