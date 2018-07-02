using System.Collections.Generic;

namespace schedule.data.helpers.objs
{
    public class ChuyenKhoaSort
    {
        int maCK;

        public int MaCK
        {
            get { return maCK; }
            set { maCK = value; }
        }
        int maCKqd;

        public int MaCK_QD
        {
            get { return maCKqd; }
            set { maCKqd = value; }
        }
        int loaiCK;

        public int LoaiCK
        {
            get { return loaiCK; }
            set { loaiCK = value; }
        }
        string chuyenKhoa;

        public string ChuyenKhoa
        {
            get { return chuyenKhoa; }
            set { chuyenKhoa = value; }
        }
        /// <summary>
        /// 1. Phòng khám ,Lâm sàng
        /// 2. Cận lâm sàng
        /// </summary>

        public static List<ChuyenKhoaSort> DanhSachChuyenKhoa
        {
            get
            {
                List<ChuyenKhoaSort> _lChuyenKhoa = new List<ChuyenKhoaSort>();
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 0, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKNoi, MaCK_QD = 2, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 1, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKNgoai, MaCK_QD = 10, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 2, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKNhi, MaCK_QD = 3, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 3, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKRangHamMat, MaCK_QD = 16, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 4, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKTaiMuiHong, MaCK_QD = 15, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 5, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKMat, MaCK_QD = 14, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 6, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKTruyenNhiem, MaCK_QD = 2, LoaiCK = 1 });// chưa có
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 7, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKDongY, MaCK_QD = 8, LoaiCK = 1 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 8, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKSan, MaCK_QD = 13, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 9, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKDaLieu, MaCK_QD = 5, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 10, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKKhamSucKhoe, MaCK_QD = 2, LoaiCK = 3 });///

                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 11, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.SieuAm, MaCK_QD = 2, LoaiCK = 3 });//
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 12, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.SieuAm_Doppler, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 13, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.X_Quang, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 14, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.DienTim, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 15, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuThuat, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 16, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.PhauThuat, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 17, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.NoiSoi, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 18, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.NoiSoiTaiMuiHong, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 19, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ChucNangHoHap, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 20, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.DoMatDoXuong, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 21, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.LuuHuyetNao, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 22, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XetNghiem, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 23, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.TrucCapCuu, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 24, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.X_QuangCT, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 25, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNHoaSinhMau, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 26, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNHuyetHoc, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 27, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNNuocTieu, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 28, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNKhac, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 29, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNDichChocDo, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 30, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNHoaSinhNTTo, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 31, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNTeBaoNuocDich, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 32, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNViSinh, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 33, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNDom, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 34, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuocThuong_DT, MaCK_QD = 2, LoaiCK = 2 });//"Thuốc thường
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 35, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuocThuong_khangsinh, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 36, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuocThuong_vitamin, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 37, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuocThuong_CPYHCT, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 38, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.GayNghien, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 39, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.HuongTamThan, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 40, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.VTYT_TieuHao, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 41, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.HoaChat, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 42, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuocTreEm, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 43, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuocDongY, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 44, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.YCu, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 45, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.TamThan, MaCK_QD = 6, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 46, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.Lao, MaCK_QD = 4, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 47, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKHSCCCD, MaCK_QD = 1, LoaiCK = 1 });//Hồi sức cấp cứu và chống độc", MaCK_QD = 1, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 48, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKNoiTiet, MaCK_QD = 7, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 49, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKGMHSuc, MaCK_QD = 9, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 50, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKBong, MaCK_QD = 11, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 51, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKUngBuou, MaCK_QD = 12, LoaiCK = 1 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 52, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.KSK, MaCK_QD = 0, LoaiCK = 1 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 53, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuocThuong_DT, MaCK_QD = 2, LoaiCK = 2 });//"Thuốc thường (DT)"
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 54, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThuocThuong_Corticoid, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 55, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.Mau, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 56, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.CKDienNaoDo, MaCK_QD = 2, LoaiCK = 3 });///
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 57, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNHoaSinhMienDich, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 58, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.TracNghiemTamLy, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 59, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.ThucPhamChucNang, MaCK_QD = 2, LoaiCK = 2 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 60, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNMoBenhHoc, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 61, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.XNDongCamMau, MaCK_QD = 2, LoaiCK = 3 });
                _lChuyenKhoa.Add(new ChuyenKhoaSort { MaCK = 62, ChuyenKhoa = TieuNhomRG_ChuyenKhoa.TaiSan, MaCK_QD = 2, LoaiCK = 2 });
                return _lChuyenKhoa;
            }
        }
    }
}
