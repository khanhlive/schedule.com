
namespace schedule.data.erps.his
{
    using System;

    public partial class HIS_CANLAMSANG_CHITIET
    {
        public int ID { get; set; }
        public Nullable<int> CanLamSang_ID { get; set; }
        public string DichvuChitiet_Ma { get; set; }
        public string ChiDinh { get; set; }
        public Nullable<int> Status { get; set; }
        public string CanBo_Ma { get; set; }
        public Nullable<System.DateTime> Ngaythang { get; set; }
        public Nullable<int> ChiDinh_ID { get; set; }
        public Nullable<int> STTHT { get; set; }
        public string KetQua { get; set; }
        public Nullable<double> SoPhieu { get; set; }
        public string KetquaXetNghiem { get; set; }
        public string DuongDan { get; set; }
        public string DuongDan2 { get; set; }
    }
}
