using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.data.helpers.objs
{
    #region phân loại xuất
    public class PhanLoaiXuat
    {
        string phanloai;

        public string PhanLoai
        {
            get { return phanloai; }
            set { phanloai = value; }
        }
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        bool check;

        public bool Check
        {
            get { return check; }
            set { check = value; }
        }
        static List<PhanLoaiXuat> _lPhanLoaiXuat = new List<PhanLoaiXuat>();
        public static List<PhanLoaiXuat> _setPhanLoaiXuat()
        {
            _lPhanLoaiXuat = new List<PhanLoaiXuat>();
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 0, PhanLoai = "Xuất ngoại trú", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 1, PhanLoai = "Xuất nội trú", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 2, PhanLoai = "Xuất nội bộ", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 3, PhanLoai = "Xuất ngoài BV", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 4, PhanLoai = "Xuất điều trị ngoại trú", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 5, PhanLoai = "Xuất Cận Lâm Sàng", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 6, PhanLoai = "Xuất tủ trực", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 7, PhanLoai = "Xuất phòng khám", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 8, PhanLoai = "Xuất kiểm nghiệm", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 9, PhanLoai = "Xuất khác", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 10, PhanLoai = "Xuất sản xuất", Check = true });
            _lPhanLoaiXuat.Add(new PhanLoaiXuat { Id = 11, PhanLoai = "Xuất lâm sàng", Check = true });
            return _lPhanLoaiXuat;
        }
    }

    #endregion
}
