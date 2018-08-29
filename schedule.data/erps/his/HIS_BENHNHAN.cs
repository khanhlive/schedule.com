using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using schedule.data.enums;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace schedule.data.erps.his
{
    [Table("VSS_BENHNHAN")]
    public class HIS_BENHNHAN : EntityBase<HIS_BENHNHAN>
    {
        #region Properties
        [Key]
        public int ID { get; set; } //(int, not null)
        public string MaBenhNhan { get; set; } //(varchar(15), not null)
        public int Tuoi { get; set; } //(int, null)
        public string GioiTinh_Ma { get; set; } //(varchar(10), null)
        public DateTime NgayThangNamSinh { get; set; } //(datetime, null)
        public string DiaChi { get; set; } //(nvarchar(250), null)
        public string DoiTuong { get; set; } //(nvarchar(10), null)
        public DateTime NgayNhap { get; set; } //(datetime, null)
        public string SoTheBHYT { get; set; } //(varchar(20), null)
        public string MaCoSo { get; set; } //(varchar(10), null)
        public int LaBenhNhanNoiTru { get; set; } //(int, null)
        public string TrieuChung { get; set; } //(nvarchar(250), null)
        public int PhongBan_Ma { get; set; } //(int, null)
        public int TuyenBenhVien { get; set; } //(int, null)
        public string ChanDoanNoiGioiThieu { get; set; } //(nvarchar(250), null)
        public int CapCuu { get; set; } //(int, null)
        public int NoiTinh { get; set; } //(int, null)
        public int SoThuTu { get; set; } //(int, null)
        public int TrangThaiBenhNhan { get; set; } //(int, null)
        public DateTime HanBaoHiemTu { get; set; } //(date, null)
        public DateTime HanBaoHiemDen { get; set; } //(date, null)
        public string NgaySinh { get; set; } //(char(2), null)
        public string ThangSinh { get; set; } //(char(2), null)
        public string NamSinh { get; set; } //(char(4), null)
        public string BenhVien_Ma { get; set; } //(varchar(10), null)
        public string ChuyenKhoa_Ma { get; set; } //(nvarchar(50), null)
        public string TenBenhNhan { get; set; } //(nvarchar(250), null)
        public int LaNgoaiGio { get; set; } //(int, null)
        public int TuyenDuoi { get; set; } //(int, null)
        public int SoKhamBenh { get; set; } //(int, null)
        public decimal MucHuongBaoHiem { get; set; } //(decimal(1,0), null)
        public string KhuVuc { get; set; } //(char(2), null)
        public DateTime NgayHanMuc { get; set; } //(date, null)
        public decimal LuongCoSo { get; set; } //(decimal(1,0), null)
        public bool LaUuTien { get; set; } //(bit, null)
        public bool DieuTriNgoaiTru { get; set; } //(bit, not null)
        public string DoiTuong_Ma { get; set; } //(char(2), null)
        public int Person_Ma { get; set; } //(int, null)
        public bool NoThe { get; set; } //(bit, not null)
        public int DoiTuongBenhNhan_Ma { get; set; } //(int, not null)
        public string Ma_LienKet { get; set; } //(varchar(50), null)
        public string MaKhamChuaBenh { get; set; } //(varchar(10), not null)
        public bool Export { get; set; } //(bit, not null)
        public string CanBo_Ma { get; set; } //(varchar(10), null)

        #endregion

        #region Method

        public override IEnumerable<HIS_BENHNHAN> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(this.sqlHelper.ConnectionString))
                {
                    IEnumerable<HIS_BENHNHAN> benhnhans = dbConnection.Query<HIS_BENHNHAN>(@"SELECT vb.* FROM VSS_BENHNHAN AS vb", commandType: CommandType.Text).ToList();
                    return benhnhans;
                }
            }
            catch (Exception ex)
            {
                log.Error("Generate BENHNHAN", ex);
                return null;
            }
            
        }

        public DataTable GetThongKeTheoPhongBan(DateTime? tungay,DateTime? denngay)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                return this.sqlHelper.ExecuteDataTable("GetThongKeHosoBenhnhan", new string[] { "@TuNgay", "@Denngay" }, new object[] { tungay, denngay }); 
            }
            catch (Exception ex)
            {
                log.Error("Generate GetThongKeTheoPhongBan();", ex);
                return null;
            }
        }

        public override IEnumerable<HIS_BENHNHAN> GetAllActive()
        {
            return this.GetAll();
        }

        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(HIS_BENHNHAN entity)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(this.sqlHelper.ConnectionString))
                {
                    var returnValue = dbConnection.Delete<HIS_BENHNHAN>(entity);
                    return returnValue ? SqlResultType.OK : SqlResultType.Failed;
                }
            }
            catch (Exception ex)
            {
                log.Error("Delete BENHNHAN", ex);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override HIS_BENHNHAN Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            return this.Insert(this);
        }

        public override SqlResultType Insert(HIS_BENHNHAN entity)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(this.sqlHelper.ConnectionString))
                {
                    var returnValue = dbConnection.Insert<HIS_BENHNHAN>(entity);
                    return returnValue > 0 ? SqlResultType.OK : SqlResultType.Failed;
                }
            }
            catch (Exception ex)
            {
                log.Error("Insert BENHNHAN", ex);
                return SqlResultType.Exception;
            }
            
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(HIS_BENHNHAN entity)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(this.sqlHelper.ConnectionString))
                {
                    var returnValue = dbConnection.Update<HIS_BENHNHAN>(entity);
                    return returnValue ? SqlResultType.OK : SqlResultType.Failed;
                }
            }
            catch (Exception ex)
            {
                log.Error("Update BENHNHAN", ex);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<HIS_BENHNHAN> DataReaderToList(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HIS_BENHNHAN> GetFilter()
        {
            return GetListByDapper("select top(200) * from VSS_BENHNHAN", CommandType.Text);
        }

        #endregion
    }

}
