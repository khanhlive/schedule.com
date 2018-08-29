
namespace schedule.data.erps.his
{
    using System;

    public partial class HIS_DICHVUCHITIET
    {
        public int ID { get; set; }
        public string Ma { get; set; }
        public Nullable<int> DichVu_ma { get; set; }
        public string Ten { get; set; }
        public string TriSoBinhThuong { get; set; }
        public Nullable<int> STT { get; set; }
        public Nullable<int> Status { get; set; }
        public string DonVi { get; set; }
        public string TriSoBinhThuong_Nu { get; set; }
        public string TriSoNam_Tu { get; set; }
        public string TriSoNam_Den { get; set; }
        public string TriSoNu_Tu { get; set; }
        public string TriSoNu_Den { get; set; }
        public string TenMay { get; set; }
        public string TriSoBinhThuong_Nam { get; set; }
        public string KetQua { get; set; }
        public Nullable<byte> SoThuTu_F { get; set; }
        public byte SThuTu_R { get; set; }
    }
}
