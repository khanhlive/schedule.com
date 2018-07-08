using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.vss
{
    public class VSS_PERSON : EntityBase<VSS_PERSON>
    {
        #region Properties

        public int ID { get; set; } //(int, not null)
        public string SoTheBHYT { get; set; } //(varchar(16), not null)
        public string DoiTuong_Ma { get; set; } //(varchar(10), null)
        public string TenBenhNhan { get; set; } //(nvarchar(100), not null)
        public string GioiTinh_Ma { get; set; } //(varchar(10), not null)
        public string DiaChi { get; set; } //(nvarchar(250), null)
        public DateTime HanBaoHiemTu { get; set; } //(date, null)
        public DateTime HanBaoHiemDen { get; set; } //(date, null)
        public DateTime NgayCap { get; set; } //(date, null)
        public int Status { get; set; } //(int, null)
        public string MaCoSo { get; set; } //(varchar(10), null)
        public string Tinh_Ma { get; set; } //(varchar(10), null)
        public string Huyen_Ma { get; set; } //(varchar(10), null)
        public string Xa_Ma { get; set; } //(varchar(10), null)
        public string NoiSinh { get; set; } //(int, null)
        public string NgaySinh { get; set; } //(varchar(2), null)
        public string ThangSinh { get; set; } //(varchar(2), null)
        public string NamSinh { get; set; } //(varchar(2), null)
        public DateTime NgayThangNamSinh { get; set; } //(datetime, null)
        public DateTime NgayHanMuc { get; set; } //(date, null)
        public string KhuVuc { get; set; } //(varchar(2), null)

        #endregion


        #region Method

        public override IEnumerable<VSS_PERSON> GetAll()
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.Text;
                SqlDataReader dt = this.sqlHelper.ExecuteReader(@"SELECT
	vp.ID,
	vp.SoTheBHYT,
	vp.DoiTuong_Ma,
	vp.TenBenhNhan,
	vp.GioiTinh_Ma,
	vp.DiaChi,
	vp.HanBaoHiemTu,
	vp.HanBaoHiemDen,
	vp.NgayCap,
	vp.[Status],
	vp.MaCoSo,
	vp.Tinh_Ma,
	vp.Huyen_Ma,
	vp.Xa_Ma,
	vp.NoiSinh,
	vp.NgaySinh,
	vp.ThangSinh,
	vp.NamSinh,
	vp.NgayThangNamSinh,
	vp.NgayHanMuc,
	vp.KhuVuc
FROM
	VSS_PERSON AS vp");
                return this.DataReaderToList(dt);
            }
            catch (Exception e)
            {
                this.sqlHelper.Close();
                log.Error("GetAll PERSON", e);
                return null;
            }
        }

        public override IEnumerable<VSS_PERSON> GetAllActive()
        {
            return this.GetAll();
        }


        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(VSS_PERSON entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override VSS_PERSON Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(VSS_PERSON entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(VSS_PERSON entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<VSS_PERSON> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<VSS_PERSON> people = new List<VSS_PERSON>();
                while (dataReader.Read())
                {
                    VSS_PERSON person  = new VSS_PERSON();
                    person.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    person.DiaChi = dataReader["DiaChi"].ToString();
                    person.DoiTuong_Ma = dataReader["DoiTuong_Ma"].ToString();
                    person.GioiTinh_Ma = dataReader["GioiTinh_Ma"].ToString();
                    if (dataReader["HanBaoHiemDen"] != null)
                        person.HanBaoHiemDen = Convert.ToDateTime(dataReader["HanBaoHiemDen"]);
                    if (dataReader["HanBaoHiemTu"] != null)
                        person.HanBaoHiemTu = Convert.ToDateTime(dataReader["HanBaoHiemTu"].ToString());
                    person.Huyen_Ma = dataReader["Huyen_Ma"].ToString();
                    person.KhuVuc = dataReader["KhuVuc"].ToString();
                    person.MaCoSo= dataReader["MaCoSo"].ToString();
                    person.NamSinh= dataReader["NamSinh"].ToString();
                    if (dataReader["NgayCap"] != null)
                        person.NgayCap= Convert.ToDateTime(dataReader["NgayCap"].ToString());
                    if (dataReader["NgayHanMuc"] != null)
                        person.NgayHanMuc = Convert.ToDateTime(dataReader["NgayHanMuc"].ToString());
                    person.NgaySinh = dataReader["NgaySinh"].ToString();
                    if (dataReader["NgayThangNamSinh"] != null)
                        person.NgayThangNamSinh = Convert.ToDateTime(dataReader["NgayThangNamSinh"].ToString());
                    person.NoiSinh= dataReader["NoiSinh"].ToString();
                    person.SoTheBHYT= dataReader["SoTheBHYT"].ToString();
                    person.Status = dataReader["Status"] == null ? 0 : DataConverter.StringToInt(dataReader["Status"].ToString());
                    person.TenBenhNhan= dataReader["TenBenhNhan"].ToString();
                    person.ThangSinh= dataReader["ThangSinh"].ToString();
                    person.Tinh_Ma = dataReader["Tinh_Ma"].ToString();
                    person.Xa_Ma = dataReader["Xa_Ma"].ToString();
                    people.Add(person);
                }
                return people;
            }
            catch (Exception ex)
            {
                log.Error("Generate PERSON", ex);
                return null;
            }
        }
        #endregion
    }

}
