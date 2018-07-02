using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.dictionary
{

    public class DIC_TIEUNHOMDICHVU : EntityBase<DIC_TIEUNHOMDICHVU>
    {
        public DIC_TIEUNHOMDICHVU()
        {
            this.StoreGetAll = "GetAllTieuNhomDichVu";
            this.StoreGetAllActive = "GetTieuNhomDichVu";
        }
        [ValueMember]
        public int MaTieuNhom { get; set; }
        [DisplayMember]
        public string TenTieuNhom { get; set; }
        public string TenRutGon { get; set; }
        public Nullable<int> MaNhom { get; set; }
        public string TenNhom { get; set; }
        public Nullable<byte> STT { get; set; }
        public int? BHYT { get; set; }
        public int Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_TIEUNHOMDICHVU tieunhom)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteTieuNhomDichVu", new string[] { "@MaTieuNhom" }, new object[] { tieunhom.MaTieuNhom });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete TIEU NHOM DICH VU", e);
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

        public override SqlResultType Insert(DIC_TIEUNHOMDICHVU tieunhom)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[InsertTieuNhomDichVu]",
                    new string[] { "@TenTieuNhom", "@MaNhom", "@TenRutGon", "@Stt", "@Status" },
                    new object[] { tieunhom.TenTieuNhom, tieunhom.MaNhom, tieunhom.TenRutGon, tieunhom.STT, tieunhom.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert TIEU NHOM DICH VU", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_TIEUNHOMDICHVU tieunhom)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[UpdateTieuNhomDichVu]",
                    new string[] { "@MaTieuNhom", "@TenTieuNhom", "@MaNhom", "@TenRutGon", "@Stt", "@Status" },
                    new object[] { tieunhom.MaTieuNhom, tieunhom.TenTieuNhom, tieunhom.MaNhom, tieunhom.TenRutGon, tieunhom.STT, tieunhom.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update TIEU NHOM DICH VU", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_TIEUNHOMDICHVU> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_TIEUNHOMDICHVU> dstieunhom = new List<DIC_TIEUNHOMDICHVU>();
                while (dataReader.Read())
                {
                    DIC_TIEUNHOMDICHVU tieunhom = new DIC_TIEUNHOMDICHVU();
                    tieunhom.MaTieuNhom = DataConverter.StringToInt(dataReader["MaTieuNhom"].ToString());
                    tieunhom.TenTieuNhom = dataReader["TenTieuNhom"].ToString();
                    tieunhom.TenNhom = dataReader["TenNhom"].ToString();
                    tieunhom.MaNhom = DataConverter.StringToInt(dataReader["MaNhom"].ToString());
                    tieunhom.TenRutGon = (dataReader["TenRutGon"].ToString());
                    tieunhom.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    tieunhom.BHYT = DataConverter.ToInt(dataReader["BHYT"].ToString());
                    tieunhom.STT = DataConverter.ToByte(dataReader["STT"].ToString());

                    dstieunhom.Add(tieunhom);
                }
                return dstieunhom;
            }
            catch (Exception e)
            {
                log.Error("Generate TIEU NHOM DICH VU", e);
                return null;
            }
        }
    }
}
