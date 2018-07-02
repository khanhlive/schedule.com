using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.dictionary
{
    public class DIC_HUYEN : EntityBase<DIC_HUYEN>
    {
        public DIC_HUYEN():base()
        {
            this.StoreGetAll = "GetAllHuyen";
            this.StoreGetAllActive = "GetHuyen";
        }

        [ValueMember]
        public string MaHuyen { get; set; }
        [DisplayMember]
        public string TenHuyen { get; set; }
        public string Cap { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public int Status { get; set; }
        public IEnumerable<DIC_HUYEN> GetAllHuyenbyTinh(string matinh)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetHuyenByTinh", new string[] { "@MaTinh" }, new object[] { matinh });
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByTinh DANH MUC HUYEN/THI XA", ex);
                return null;
            }

        }
        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_HUYEN huyen)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteHuyen", new string[] { "@MaHuyen" }, new object[] { huyen.MaHuyen });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Delete DANH MUC HUYEN/THI XA", ex);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new System.NotImplementedException();
        }

        public override SqlResultType Get(object key)
        {
            throw new System.NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_HUYEN huyen)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertHuyen",
                    new string[] { "@MaHuyen", "@MaTinh", "@TenHuyen", "@Status","@Cap" },
                    new object[] { huyen.MaHuyen, huyen.MaTinh, huyen.TenHuyen, huyen.Status,huyen.Cap }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Insert DANH MUC HUYEN/THI XA", ex);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_HUYEN huyen)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateHuyen",
                    new string[] { "@MaHuyen", "@MaTinh", "@TenHuyen", "@Status","@Cap" },
                    new object[] { huyen.MaHuyen, huyen.MaTinh, huyen.TenHuyen, huyen.Status, huyen.Cap }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Update DANH MUC HUYEN/THI XA", ex);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_HUYEN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_HUYEN> dsChuyenKhoa = new List<DIC_HUYEN>();
                while (dataReader.Read())
                {
                    DIC_HUYEN huyen = new DIC_HUYEN();
                    huyen.MaHuyen = dataReader["MaHuyen"].ToString();
                    huyen.TenHuyen = dataReader["TenHuyen"].ToString();
                    huyen.MaTinh = dataReader["MaTinh"].ToString();
                    huyen.TenTinh = dataReader["TenTinh"].ToString();
                    huyen.Cap = dataReader["Cap"].ToString();
                    huyen.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsChuyenKhoa.Add(huyen);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate DANH MUC HUYEN/THI XA", ex);
                return null;
            }
        }
    }
}
