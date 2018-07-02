using System;
using System.Collections.Generic;
using schedule.data.enums;
using schedule.data.helpers.objs;

namespace schedule.data
{

    public static class Common
    {
        public static string TenCQCQ = "";
        public static string DiaDanh = "";
        public static string TenCQrg = "";
        public static int _tuyenduoi = 0;
        public static string MaBV = "12122";
        public static string TenCQ = "Bệnh viện đa khoa huyện Bình Giang";
        public static string DiaChi = "";
        public static int LamTronSo = 0;
        public static string TenCQBH = "";
        public static string TenCQCQBH = "";
        public static string MaHuyen = "";
        public static string MaTinh = "";
        public static string GiamDoc = "";
        public static int MaKP = 0;
        public static string PLoaiKP = "-1";
        public static string ChuyenKhoa = "";
        public static string MaCB = "0";
        public static string TenDN = "";
        public static int GHanTT100 = 172500;
        public static bool CoTheChuyen = true;
        public static string TruongKhoaDuoc = "";
        public static string KeToanTruong = "";
        public static string KeToanVP = "";
        public static string KeToanVPnt = "";
        public static string NguoiLapBieu = "";
        public static string ThuKho = "";
        public static string GiamDinhBH = "";
        public static string GiamDinhBH2 = "";
        public static int PP_SoVV = 0;
        public static int PP_SoRV = 0;
        public static int PP_SoCV = 0;
        public static int PP_SoLT = 0;
        public static int PP_SoBA = 0;
        public static int PP_SoKB = 0;
        /// <summary>
        /// 0: gửi thủ công, 1: gửi tự động khi duyệt chi phí
        /// 0: ngoại trú; 1: nội trú-- dung
        /// </summary>
        public static int[] PPXuat_BHXH = new int[2]{-1,-1};
        /// <summary>
        /// [0]: giờ bắt đầu buổi sáng
        /// [1]: giờ bắt đầu buổi chiều
        /// </summary>
        public static int[] GioTu = new int[2] { 07, 13 };
        /// <summary>
        /// [0]: phút bắt đầu buổi sáng
        /// [1]: phút bắt đầu buổi chiều
        /// </summary>
        public static int[] PhutTu = new int[2] { 30, 30 };
        /// <summary>
        /// [0]: giờ kết thúc buổi sáng
        /// [1]: giờ kết thúc buổi chiều
        /// </summary>
        public static int[] GioDen = new int[2] { 11, 17 };
        public static int[] PhutDen = new int[2] { 30, 30 };
        public static double SoLuongTon = 0;
        public static DateTime? HanDung = null;
        public static DateTime NgayKichHoat = System.DateTime.Now;
        public static bool _checkpass = false;
        public static string TruongKhoaLS = "";
        public static string passql = "abc";
        public static string accountsql = "sa";
        public static string TenCSDL = "QLBV_04011";
        public static string TenServer = "server";
        public static string StrCon = @"metadata=res://*/QLBVEntity.csdl|res://*/QLBVEntity.ssdl|res://*/QLBVEntity.msl;provider=System.Data.SqlClient;provider connection string=';Data Source=" + TenServer + ";Initial Catalog=" + TenCSDL + ";User ID=" + accountsql + ";Password=" + passql + ";MultipleActiveResultSets=True';";
        public static string[] FormatString = new string[2] { "{0:0,0}", "{0:0,0}" };
        public static StringDatetimeType FormatDate = StringDatetimeType.FullDate;
        public static int PPXuat = 1;
        public static string _maCC = "";
        public static int CapDo = 1;
        public static int MaKho = 0;
        public static string LoaiPM = "QLBV";
        public static string MaNSach = "";
        public static string KeToanVPdv = "";
        public static int InPhoi = 0;
        public static int TamThuCLS = 0;
        public static bool keNhieuKho=false;
        /// <summary>
        /// 0: mặc định
        /// 1: chỉ hiện thị đường dùng và chọn HDSD trong danh sách
        /// </summary>
        public static int HDSDDonThuoc = 0;
        public static string thongtinketnoi = "server|CLS|sa|cuongthuong@1|KetQua|MaDVct|KetQua|";
        public static string DuongDan = "D:\\";
        public static int GetICD = 0;
        public static string formatAge = "36-45";
        public static string ngayCNhat = "30/03/2016 10:00";
        public static string _inMauCD = "A5";
        public static bool[] _Visible_CDHA = new bool[4] { true, false, true, true };
        public static Object[,] MangHaiChieu;
        /// <summary>
        /// 0: hang đặc biệt
        /// 1: hạng 1
        /// 2: hạng 2
        /// 3: hạng 3
        /// 4: hạng 4
        /// </summary>
        public static string[] mack_theoHangBV = new string[5] { "1895", "1896", "1897", "1898", "1899" };
        /// <summary>
        /// 0: lưu chỉ định
        /// 1: Lưu kết quả
        /// 2: lưu kết quả(backup)
        /// 3:
        /// 4:
        /// 5:
        /// 10: đường dẫn lưu file
        /// </summary>
        public static string[] xmlFilePath_LIS = new string[] { "C:\\schedule", "C:\\schedule", "C:\\schedule", "", "", "", "", "", "", "", "", "" };
        public static string ImageFilePath_CBInfo = "";
        // public static string _test = "...Checking";
        public static string _test = "";
        public static int _idDTBHYT = -1;
        public static DateTime ngayGiaMoi = Convert.ToDateTime("15/08/2016");
        public static DateTime ngayGiaMoiDV = Convert.ToDateTime("01/06/2017");
        
        /// <summary>
        /// 0. "Khỏi"
        /// 1. "Đỡ|Giảm"
        /// 2. "Không T.đổi"
        /// 3. "Nặng hơn"
        /// 4. "Tử vong"
        /// </summary>

        public static string[] _ketQuaDT = new string[5] { "Khỏi", "Đỡ|Giảm", "Không T.đổi", "Nặng hơn", "Tử vong" };
        public static string[] _phuongAn = new string[5] { "Về nhà(Ra viện)", "Vào viện", "Chuyển viện", "Chuyển khoa|phòng", "Đang điều trị" };

        public static List<NhomDV_QD> NhomDVQD => NhomDV_QD.SetNhomDV();
        public static List<ChuyenKhoaSort> _lChuyenKhoa => ChuyenKhoaSort.DanhSachChuyenKhoa;
        
        public static List<TaiNan> _listTaiNan => TaiNan.Init;
        
        public static List<PhimXQuang_Size> _lCoPhim => PhimXQuang_Size.Init;
        
        public static List<KieuDonBN> _lKieuDonBN => KieuDonBN.Init;   
       

    }

}
