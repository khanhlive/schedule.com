using System.Collections.Generic;

namespace schedule.data.helpers.objs
{
    public class KieuDonBN
    {
        public int Value { set; get; }
        public string KieuDon { set; get; }
        public static List<KieuDonBN> Init
        {
            get
            {
                List<KieuDonBN> list = new List<KieuDonBN>();
                list.Add(new KieuDonBN { Value = 0, KieuDon = "Hàng ngày" });
                list.Add(new KieuDonBN { Value = 1, KieuDon = "Bổ sung" });
                list.Add(new KieuDonBN { Value = 2, KieuDon = "Trả thuốc(BN)" });
                list.Add(new KieuDonBN { Value = 3, KieuDon = "Lĩnh về khoa" });
                list.Add(new KieuDonBN { Value = 4, KieuDon = "Trả thuốc(Khoa)" });
                list.Add(new KieuDonBN { Value = 5, KieuDon = "Trực" });
                return list;
            }
        }
    }
}
