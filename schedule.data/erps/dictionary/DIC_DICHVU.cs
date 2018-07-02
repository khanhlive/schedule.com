using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using Dapper;
using System.Linq;

namespace schedule.data.erps.dictionary
{
    public class DIC_DICHVU : EntityBase<DIC_DICHVU>
    {
        public DIC_DICHVU()
        {
            this.StoreGetAll = "GetAllDichVu";
        }


        #region Method


        public override IEnumerable<DIC_DICHVU> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DIC_DICHVU> GetAllDichVu(PhanLoaiDichVu phanloai)
        {
            if (!string.IsNullOrEmpty(this.StoreGetAll) && !string.IsNullOrWhiteSpace(this.StoreGetAll))
            {
                try
                {
                    this.CreateConnection();
                    this.sqlHelper.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dt = this.sqlHelper.ExecuteReader(this.StoreGetAll, new string[] { "@LoaiDichVu" }, new object[] { (int)phanloai });
                    return this.DataReaderToList(dt);
                }
                catch (Exception e)
                {
                    this.sqlHelper.Close();
                    log.Error(string.Format("GetAll DICH VU(phanloai:{0})", (int)phanloai), e);
                    return null;
                }
            }
            else return null;
        }
        public IEnumerable<DIC_DICHVU> GetAllDichVu2(PhanLoaiDichVu phanloai)
        {
            if (!string.IsNullOrEmpty(this.StoreGetAll) && !string.IsNullOrWhiteSpace(this.StoreGetAll))
            {
                this.CreateConnection();
                try
                {
                    using (IDbConnection dbConnection = new SqlConnection(this.sqlHelper.ConnectionString))
                    {
                        DynamicParameters parameter = new DynamicParameters();
                        parameter.Add("@LoaiDichVu", (int)phanloai, DbType.Int32, ParameterDirection.Input);
                        IEnumerable<DIC_DICHVU> dichvus = dbConnection.Query<DIC_DICHVU>(this.StoreGetAll, parameter, null, true, null, CommandType.StoredProcedure).ToList();
                        return dichvus;
                    }
                }
                catch (Exception e)
                {
                    this.sqlHelper.Close();
                    log.Error(string.Format("GetAll DICH VU(phanloai:{0})", (int)phanloai), e);
                    return null;
                }
            }
            else return null;
        }


        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_DICHVU entity)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteDichVu", new string[] { "@MaDichVu" }, new object[] { entity.MaDichVu });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete DICH VU", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_DICHVU entity)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDichVu",
                    new string[] { "@TenDichVu", "@DonViTinh", "@DonGia", "@TrongDanhMuc", "@Loai", "@BaoHiemThanhToan", "@DichVuKyThuatCao", "@PhanLoaiDichVu",
                        "@MaTieuNhomDichVu", "@MaQuyetDinh", "@TenRutGon", "@SoThuTu", "@DonGia2", "@SoThuTuQuyetDinh", "@MaTam", "@MaNhom", "@SoQuyetDinh",
                        "@MaDichVuBackUp", "@MaPhongBanSD", "@DongiaT7", "@DonGiaBHYT", "@DanhSachDonGia", "@GiaDichVuDot2", "@GiaPhuThu", "@DanhSachDoiTuongBenhNhan", "@Status" },
                    new object[] { entity.TenDichVu, entity.DonViTinh, entity.DonGia, entity.TrongDanhMuc, entity.Loai, entity.BaoHiemThanhToan,
                        entity.DichVuKyThuatCao, entity.PhanLoaiDichVu, entity.MaTieuNhomDichVu, entity.MaQuyetDinh, entity.TenRutGon,
                        entity.SoThuTu, entity.DonGia2, entity.SoThuTuQuyetDinh, entity.MaTam, entity.MaNhom, entity.SoQuyetDinh,
                        entity.MaDichVuBackUp, entity.MaPhongBanSD, entity.DongiaT7, entity.DonGiaBHYT,
                        entity.DanhSachDonGia, entity.GiaDichVuDot2, entity.GiaPhuThu, entity.DanhSachDoiTuongBenhNhan, entity.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq > 1 ? 1 : 0);
            }
            catch (Exception e)
            {
                log.Error("Insert DICH VU", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_DICHVU entity)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDichVu",
                    new string[] { "@MaDichVu", "@TenDichVu", "@DonViTinh", "@DonGia", "@TrongDanhMuc", "@Loai", "@BaoHiemThanhToan", "@DichVuKyThuatCao", "@PhanLoaiDichVu",
                        "@MaTieuNhomDichVu", "@MaQuyetDinh", "@TenRutGon", "@SoThuTu", "@DonGia2", "@SoThuTuQuyetDinh", "@MaTam", "@MaNhom", "@SoQuyetDinh",
                        "@MaDichVuBackUp", "@MaPhongBanSD", "@DongiaT7", "@DonGiaBHYT", "@DanhSachDonGia", "@GiaDichVuDot2", "@GiaPhuThu", "@DanhSachDoiTuongBenhNhan", "@Status" },
                    new object[] {entity.MaDichVu, entity.TenDichVu, entity.DonViTinh, entity.DonGia, entity.TrongDanhMuc, entity.Loai, entity.BaoHiemThanhToan,
                        entity.DichVuKyThuatCao, entity.PhanLoaiDichVu, entity.MaTieuNhomDichVu, entity.MaQuyetDinh, entity.TenRutGon,
                        entity.SoThuTu, entity.DonGia2, entity.SoThuTuQuyetDinh, entity.MaTam, entity.MaNhom, entity.SoQuyetDinh,
                        entity.MaDichVuBackUp, entity.MaPhongBanSD, entity.DongiaT7, entity.DonGiaBHYT,
                        entity.DanhSachDonGia, entity.GiaDichVuDot2, entity.GiaPhuThu, entity.DanhSachDoiTuongBenhNhan, entity.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update DICH VU", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_DICHVU> DataReaderToList(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Method DUOC

        public SqlResultType Insert_DUOC(DIC_DICHVU entity)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDichVu",
                    new string[] { "@TenDichVu","@HamLuong","@DonViTinh","@DonGia","@TrongDanhMuc","@Loai","@BaoHiemThanhToan","@TenHoatChat",
                        "@NuocSanXuat","@DuongDung","@MaTieuNhomDichVu","@SoDangKy","@DangBaoChe","@NhaSanXuat",
                    "@QuyCachPhamChat","@BaoHiemYTe","@MaQuyetDinh","@TinhTrangNhap","@NguonGoc","@YCSD","@TyLeSoChePhucChe","@TyLeBaoQuan",
                        "@BoPhanDung","@DongY","@MaNhaCungCap","@SoThuTu","@DonGia2","@SoThuTuQuyetDinh","@SoLuongMin",
                    "@DonViNhap","@TyLeSuDung","@MaTam","@TieuChuan","@TuoiTho","@MaNhom","@MaDuongDung","@SoLuong","@SoQuyetDinh",
                        "@NgayQuyetDinh","@MaCongTySanXuat","@MaCongTyDangKy","@MaDichVuBackUp","@MaPhongBanSD","@DinhMuc",
                    "@MaATC","@DongiaT7","@MaHoatChat","@DonGiaBHYT","@DanhSachDonGia","@Status","@DonGiaGioiHanTT04","@GoiThau","@LoaiThau","@NhaThau","@LoaiThuoc","@NhomThau","@PhanLoaiDichVu"},
                    new object[] { entity.TenDichVu,entity.HamLuong, entity.DonViTinh, entity.DonGia, entity.TrongDanhMuc, entity.Loai, entity.BaoHiemThanhToan,entity.TenHoatChat,entity.NuocSanXuat,
                    entity.DuongDung,entity.MaTieuNhomDichVu,entity.SoDangKy,entity.DangBaoChe,entity.NhaSanXuat,entity.QuyCachPhamChat,entity.BaoHiemYTe,entity.MaQuyetDinh,entity.TinhTrangNhap,
                    entity.NguonGoc,entity.YCSD,entity.TyLeSoChePhucChe,entity.TyLeBaoQuan,entity.BoPhanDung,entity.DongY,entity.MaNhaCungCap,entity.SoThuTu,entity.DonGia2, entity.SoThuTuQuyetDinh,
                    entity.SoLuongMin,entity.DonViNhap,entity.TyLeSuDung,entity.MaTam,entity.TieuChuan,entity.TuoiTho,entity.MaNhom,entity.MaDuongDung,entity.SoLuong,entity.SoQuyetDinh,
                    entity.NgayQuyetDinh,entity.MaCongTySanXuat,entity.MaCongTyDangKy,entity.MaDichVuBackUp,entity.MaPhongBanSD,entity.DinhMuc,entity.MaATC,entity.DongiaT7,
                        entity.MaHoatChat,entity.DonGiaBHYT,entity.DanhSachDonGia,entity.Status,entity.DonGiaGioiHanTT04,entity.GoiThau,entity.Loai,entity.NhaThau,entity.LoaiThuoc,entity.NhomThau,entity.PhanLoaiDichVu
                    });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq >= 1 ? 1 : 0);
            }
            catch (Exception e)
            {
                log.Error("Insert DUOC", e);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Insert_DUOC()
        {
            return this.Insert_DUOC(this);
        }

        public SqlResultType Update_DUOC(DIC_DICHVU entity)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDichVu",
                    new string[] { "@MaDichVu","@TenDichVu","@HamLuong","@DonViTinh","@DonGia","@TrongDanhMuc","@Loai","@BaoHiemThanhToan","@TenHoatChat",
                        "@NuocSanXuat","@DuongDung","@MaTieuNhomDichVu","@SoDangKy","@DangBaoChe","@NhaSanXuat",
                    "@QuyCachPhamChat","@BaoHiemYTe","@MaQuyetDinh","@TinhTrangNhap","@NguonGoc","@YCSD","@TyLeSoChePhucChe","@TyLeBaoQuan",
                        "@BoPhanDung","@DongY","@MaNhaCungCap","@SoThuTu","@DonGia2","@SoThuTuQuyetDinh","@SoLuongMin",
                    "@DonViNhap","@TyLeSuDung","@MaTam","@TieuChuan","@TuoiTho","@MaNhom","@MaDuongDung","@SoLuong","@SoQuyetDinh",
                        "@NgayQuyetDinh","@MaCongTySanXuat","@MaCongTyDangKy","@MaDichVuBackUp","@MaPhongBanSD","@DinhMuc",
                    "@MaATC","@DongiaT7","@MaHoatChat","@DonGiaBHYT","@DanhSachDonGia","@Status","@DonGiaGioiHanTT04","@GoiThau","@LoaiThau","@NhaThau","@LoaiThuoc","@NhomThau","@PhanLoaiDichVu"},
                    new object[] {entity.MaDichVu, entity.TenDichVu,entity.HamLuong, entity.DonViTinh, entity.DonGia, entity.TrongDanhMuc, entity.Loai, entity.BaoHiemThanhToan,entity.TenHoatChat,entity.NuocSanXuat,
                    entity.DuongDung,entity.MaTieuNhomDichVu,entity.SoDangKy,entity.DangBaoChe,entity.NhaSanXuat,entity.QuyCachPhamChat,entity.BaoHiemYTe,entity.MaQuyetDinh,entity.TinhTrangNhap,
                    entity.NguonGoc,entity.YCSD,entity.TyLeSoChePhucChe,entity.TyLeBaoQuan,entity.BoPhanDung,entity.DongY,entity.MaNhaCungCap,entity.SoThuTu,entity.DonGia2, entity.SoThuTuQuyetDinh,
                    entity.SoLuongMin,entity.DonViNhap,entity.TyLeSuDung,entity.MaTam,entity.TieuChuan,entity.TuoiTho,entity.MaNhom,entity.MaDuongDung,entity.SoLuong,entity.SoQuyetDinh,
                    entity.NgayQuyetDinh,entity.MaCongTySanXuat,entity.MaCongTyDangKy,entity.MaDichVuBackUp,entity.MaPhongBanSD,entity.DinhMuc,entity.MaATC,entity.DongiaT7,
                        entity.MaHoatChat,entity.DonGiaBHYT,entity.DanhSachDonGia,entity.Status,entity.DonGiaGioiHanTT04,entity.GoiThau,entity.Loai,entity.NhaThau,entity.LoaiThuoc,entity.NhomThau,entity.PhanLoaiDichVu
                    });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq >= 1 ? 1 : 0);
            }
            catch (Exception e)
            {
                log.Error("Update DUOC", e);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Update_DUOC()
        {
            return this.Update_DUOC(this);
        }
        #endregion

        #region Properties

        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string HamLuong { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<int> TrongDanhMuc { get; set; }
        public Nullable<int> Loai { get; set; }
        public Nullable<int> BaoHiemThanhToan { get; set; }
        public Nullable<int> DichVuKyThuatCao { get; set; }
        public Nullable<int> PhanLoaiDichVu { get; set; }
        public string TenHoatChat { get; set; }
        public string NuocSanXuat { get; set; }
        public string DuongDung { get; set; }
        public Nullable<int> MaTieuNhomDichVu { get; set; }

        public int MaNhom { get; set; }
        public string SoDangKy { get; set; }
        public string DangBaoChe { get; set; }
        public string NhaSanXuat { get; set; }
        public string QuyCachPhamChat { get; set; }
        public Nullable<int> BaoHiemYTe { get; set; }
        public string MaQuyetDinh { get; set; }
        public string TenRutGon { get; set; }
        public string TinhTrangNhap { get; set; }
        public string NguonGoc { get; set; }
        public string YCSD { get; set; }
        public Nullable<double> TyLeSoChePhucChe { get; set; }
        public Nullable<double> TyLeBaoQuan { get; set; }
        public string BoPhanDung { get; set; }
        public Nullable<bool> DongY { get; set; }
        public string PhuongPhap { get; set; }
        public string MaNhaCungCap { get; set; }
        public Nullable<int> SoThuTu { get; set; }


        public string SoThuTuQuyetDinh { get; set; }
        public Nullable<int> SoLuongMin { get; set; }
        public string DonViNhap { get; set; }
        public int TyLeSuDung { get; set; }
        public string MaTam { get; set; }
        public string TieuChuan { get; set; }
        public string TuoiTho { get; set; }
        public string MaDuongDung { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public string SoQuyetDinh { get; set; }
        public Nullable<System.DateTime> NgayQuyetDinh { get; set; }
        public Nullable<int> MaCongTySanXuat { get; set; }
        public Nullable<int> MaCongTyDangKy { get; set; }
        public string MaDichVuBackUp { get; set; }
        public Nullable<int> DinhMuc { get; set; }
        public string MaATC { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<double> DonGia2 { get; set; }
        public Nullable<double> DongiaT7 { get; set; }
        public double DonGiaBHYT { get; set; }
        public string DanhSachDonGia { get; set; }
        public Nullable<double> GiaDichVuDot2 { get; set; }
        public Nullable<double> GiaPhuThu { get; set; }
        public Nullable<double> DonGiaGioiHanTT04 { get; set; }
        public string GoiThau { get; set; }
        public string LoaiThau { get; set; }
        public string NhaThau { get; set; }
        public string LoaiThuoc { get; set; }
        public string NhomThau { get; set; }
        public string MaHoatChat { get; set; }
        public string DanhSachDoiTuongBenhNhan { get; set; }
        public string MaPhongBanSD { get; set; }
        public Nullable<int> Status { get; set; }
        #endregion



    }
}
