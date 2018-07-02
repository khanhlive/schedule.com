using System.Collections.Generic;

namespace schedule.data.enums
{
    public class LoaiPhongBan
    {
        public static string[] PhongBan = new string[] { "Cận lâm sàng", "Chức năng", "Lâm sàng", "Phòng khám", "Khoa dược", "Admin", "Kế toán", "Hành chính", "Tủ trực", "PK khu vực", "Xã phường", "BHXH " };
    }
    public class HinhThucThanhToan
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public List<HinhThucThanhToan> GetList()
        {
            List<HinhThucThanhToan> list = new List<HinhThucThanhToan>();
            list.Add(new HinhThucThanhToan { Name = "Miễn", Value = 0 });
            list.Add(new HinhThucThanhToan { Name = "BHYT", Value = 1 });
            list.Add(new HinhThucThanhToan { Name = "Thanh toán toàn bộ", Value = 2 });
            list.Add(new HinhThucThanhToan { Name = "Khám sức khỏe", Value = 3 });
            return list;
        }

    }
    public class TrongDanhMuc
    {
        private PhanLoaiDichVu loaiDichVu;
        public TrongDanhMuc()
        {
            loaiDichVu = PhanLoaiDichVu.DichVu;
        }
        public TrongDanhMuc(PhanLoaiDichVu _loai)
        {
            loaiDichVu = _loai;
        }
        //public void AddRepositoryLookupEdit(RepositoryItemLookUpEdit lookup)
        //{
        //    List<LookUpEditItem> list = new List<LookUpEditItem>();
        //    list.Add(new LookUpEditItem(0, "Ngoài danh mục"));
        //    list.Add(new LookUpEditItem(1, "Trong danh mục"));
        //    if(loaiDichVu== PhanLoaiDichVu.Duoc)
        //    {
        //        list.Add(new LookUpEditItem(2, "Chi phí kèm DV"));
        //    }
        //    lookup.DataSource = list;
        //    lookup.DisplayMember = "Text";
        //    lookup.ValueMember = "Value";
        //    lookup.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text"));
        //    lookup.ShowHeader = false;
        //}
        //public void AddLookupEdit(LookUpEdit lookup)
        //{
        //    List<LookUpEditItem> list = new List<LookUpEditItem>();
        //    list.Add(new LookUpEditItem(0, "Ngoài danh mục"));
        //    list.Add(new LookUpEditItem(1, "Trong danh mục"));
        //    if (loaiDichVu == PhanLoaiDichVu.Duoc)
        //    {
        //        list.Add(new LookUpEditItem(2, "Chi phí kèm DV"));
        //    }
        //    lookup.Properties.DataSource = list;
        //    lookup.Properties.DisplayMember = "Text";
        //    lookup.Properties.ValueMember = "Value";
        //    lookup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text"));
        //    lookup.Properties.ShowHeader = false;
        //}


    }
    public class LookUpEditItem
    {
        public LookUpEditItem()
        {
        }
        public LookUpEditItem(object value,object text)
        {
            this.Value = value;
            this.Text = text;
        }

        public object Value { get; set; }
        public object Text { get; set; }
    }
    public enum PhanLoaiDichVu
    {
        Duoc = 1,
        DichVu = 2
    }

    public sealed class PhanLoaiSieuAm
    {
        public const string Sa2D = "2D";
        public const string SaMau = "Màu";
        public const string Sa3D_4D = "3D-4D";
    }
    public sealed class PhanLoaiPhim
    {
        public const string CP13_18 = "13/18";
        public const string CP18_24 = "18/24";
        public const string CP24_30 = "24/30";
        public const string CP30_40 = "30/40";
    }
}
