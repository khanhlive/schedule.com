using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.data.helpers.objs
{
    public class TaiNan
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int? stt;
        /// <summary>
        /// Số thứ tự hiển thị
        /// </summary>
        public int? Stt
        {
            get { return stt; }
            set { stt = value; }
        }
        private int idParent;

        /// <summary>
        /// id danh mục cha
        /// </summary>
        public int IdParent
        {
            get { return idParent; }
            set { idParent = value; }
        }

        private string tenloai;

        /// <summary>
        /// Tên loại tai nạn: VD: tai nạn giao thông
        /// </summary>
        public string Tenloai
        {
            get { return tenloai; }
            set { tenloai = value; }
        }
        private int? t0;

        public int? T0
        {
            get { return t0; }
            set { t0 = value; }
        }
        private int? t5;

        public int? T5
        {
            get { return t5; }
            set { t5 = value; }
        }
        private int? t15;

        public int? T15
        {
            get { return t15; }
            set { t15 = value; }
        }
        private int? t20;

        public int? T20
        {
            get { return t20; }
            set { t20 = value; }
        }
        private int? t60;

        public int? T60
        {
            get { return t60; }
            set { t60 = value; }
        }
        private int? nam;

        public int? Nam
        {
            get { return nam; }
            set { nam = value; }
        }
        private int? nu;

        public int? Nu
        {
            get { return nu; }
            set { nu = value; }
        }
        private int? tongso;

        public int? Tongso
        {
            get { return tongso; }
            set { tongso = value; }
        }
        private int? vaovien;

        public int? Vaovien
        {
            get { return vaovien; }
            set { vaovien = value; }
        }
        private int? chuyenvien;

        public int? Chuyenvien
        {
            get { return chuyenvien; }
            set { chuyenvien = value; }
        }
        private int? tuvong;

        public int? Tuvong
        {
            get { return tuvong; }
            set { tuvong = value; }
        }
        private int ma9324;

        public int Ma9324
        {
            get { return ma9324; }
            set { ma9324 = value; }
        }
        private string ten9324;

        public string Ten9324
        {
            get { return ten9324; }
            set { ten9324 = value; }
        }
        bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public static List<TaiNan> Init
        {
            get
            {
                List<TaiNan> _listTaiNan = new List<TaiNan>();
                _listTaiNan.Add(new TaiNan { Id = 0, Stt = 0, Tenloai = "Không", Ma9324 = 0, Ten9324 = "Không", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 1, Stt = 1, Tenloai = "Tai nạn giao thông", Ma9324 = 1, Ten9324 = "Tai nạn giao thông", Status = false });
                _listTaiNan.Add(new TaiNan { Id = 2, IdParent = 1, Tenloai = "Đường bộ", Ma9324 = 1, Ten9324 = "Tai nạn giao thông", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 3, IdParent = 1, Tenloai = "Đường sắt", Ma9324 = 1, Ten9324 = "Tai nạn giao thông", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 4, IdParent = 1, Tenloai = "Đường sông", Ma9324 = 1, Ten9324 = "Tai nạn giao thông", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 5, Stt = 2, Tenloai = "Tai nạn lao động", Ma9324 = 2, Ten9324 = "Tai nạn lao động", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 6, Stt = 3, Tenloai = "Tai nạn sinh hoạt", Ma9324 = 8, Ten9324 = "Khác", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 7, Stt = 4, Tenloai = "Đánh nhau", Ma9324 = 5, Ten9324 = "Bạo lực, xung đột", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 8, Stt = 5, Tenloai = "Tự tử", Ma9324 = 6, Ten9324 = "Tự tử", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 9, Stt = 6, Tenloai = "Ngộ độc", Ma9324 = 7, Ten9324 = "Ngộ độc các loại", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 10, Stt = 7, Tenloai = "Đuối nước", Ma9324 = 3, Ten9324 = "Tai nạn dưới nước", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 11, Stt = 8, Tenloai = "Bạo lực gia đình", Ma9324 = 5, Ten9324 = "Bạo lực, xung đột", Status = true });
                _listTaiNan.Add(new TaiNan { Id = 12, Stt = 9, Tenloai = "Khác", Ma9324 = 8, Ten9324 = "Khác", Status = true });
                return _listTaiNan;
            }
        }
    }
}
