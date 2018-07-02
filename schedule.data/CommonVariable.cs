namespace schedule.data
{
    public class CommonVariable
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static int[] HangBenhVien = new int[] { 0, 1, 2, 3, 4 };
        public static string[] TuyenBenhVien = new string[] { "A", "B", "C", "D" };
        public static string[] PhuongPhapXuatDuoc = new string[] {
            "0: Hư hao số lượng trong quá trình sử dụng(xuất) thuốc đông y",
            "1: Hư hao số lượng khi nhập thuốc đông y",
            "2: không tính hư hao số lượng"
        };
        public static string[] PhuongPhapHuHao = new string[] {
            "Xuất theo giá trong danh mục",
            "Nhập trước xuất trước(có giá ưu tiên)",
            "Xuất theo hạn dùng(có giá ưu tiên)",
            "Nhập trước xuất trước(theo số lô)" };
        public static string[] DonViTinhs = new string[] { "Viên","Lần","Lọ" };

        
        public CommonVariable()
        {
            
        }
    }
}
