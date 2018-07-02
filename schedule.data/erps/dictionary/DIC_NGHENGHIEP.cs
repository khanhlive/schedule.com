
namespace schedule.data.erps.dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using schedule.data.enums;
    using schedule.data.helpers;
    public class DIC_NGHENGHIEP : EntityBase<DIC_NGHENGHIEP>
    {
        public DIC_NGHENGHIEP():base()
        {
            this.StoreGetAll = "GetAllNgheNghiep";
            this.StoreGetAllActive = "GetNgheNghiep";
        }

        public int ID { get; set; }
        [ValueMember]
        public string MaNgheNghiep { get; set; }
        [DisplayMember]
        public string TenNgheNghiep { get; set; }
        public string MoTa { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_NGHENGHIEP nghenghiep)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteNgheNghiep", new string[] { "@MaNgheNghiep" }, new object[] { nghenghiep.MaNgheNghiep });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete NGHE NGHIEP", e);
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

        public override SqlResultType Insert(DIC_NGHENGHIEP nghenghiep)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[InsertNgheNghiep]",
                    new string[] { "@MaNgheNghiep", "@TenNgheNghiep", "@MoTa" },
                    new object[] { nghenghiep.MaNgheNghiep, nghenghiep.TenNgheNghiep, nghenghiep.MoTa });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert NGHE NGHIEP", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_NGHENGHIEP nghenghiep)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[UpdateNgheNghiep]",
                    new string[] { "@MaNgheNghiep", "@TenNgheNghiep", "@MoTa" },
                    new object[] { nghenghiep.MaNgheNghiep, nghenghiep.TenNgheNghiep, nghenghiep.MoTa });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update NGHE NGHIEP", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_NGHENGHIEP> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_NGHENGHIEP> dsnghenghiep = new List<DIC_NGHENGHIEP>();
                while (dataReader.Read())
                {
                    DIC_NGHENGHIEP nghenghiep = new DIC_NGHENGHIEP();
                    nghenghiep.MaNgheNghiep = dataReader["MaNgheNghiep"].ToString();
                    nghenghiep.TenNgheNghiep = dataReader["TenNgheNghiep"].ToString();
                    nghenghiep.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    nghenghiep.MoTa = dataReader["MoTa"].ToString();

                    dsnghenghiep.Add(nghenghiep);
                }
                return dsnghenghiep;
            }
            catch (Exception e)
            {
                log.Error("Generate NGHE NGHIEP", e);
                return null;
            }
        }
    }
}
