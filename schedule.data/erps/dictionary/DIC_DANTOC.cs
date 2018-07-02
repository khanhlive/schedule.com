using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.dictionary
{
    public class DIC_DANTOC : EntityBase<DIC_DANTOC>
    {
        public DIC_DANTOC() : base()
        {
            this.StoreGetAll = "GetAllDanToc";
            this.StoreGetAllActive = "GetDanToc";
        }
        [ValueMember]
        public string MaDanToc { get; set; }
        [DisplayMember]
        public string TenDanToc { get; set; }
        public string MoTa { get; set; }
        public int Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_DANTOC danToc)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteDanToc", new string[] { "@MaDanToc" }, new object[] { danToc.MaDanToc });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete DAN TOC", e);
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

        public override SqlResultType Insert(DIC_DANTOC danToc)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDanToc", new string[] { "@MaDanToc", "@TenDanToc", "@MoTa", "@Status" }, new object[] { danToc.MaDanToc, danToc.TenDanToc, danToc.MoTa, danToc.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert dan toc", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_DANTOC danToc)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDanToc", new string[] { "@MaDanToc", "@TenDanToc", "@MoTa", "@Status" }, new object[] { danToc.MaDanToc, danToc.TenDanToc, danToc.MoTa, danToc.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update DAN TOC", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_DANTOC> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_DANTOC> dsdantoc = new List<DIC_DANTOC>();
                while (dataReader.Read())
                {
                    DIC_DANTOC danToc = new DIC_DANTOC();
                    danToc.MaDanToc = dataReader["MaDanToc"].ToString();
                    danToc.TenDanToc = dataReader["TenDanToc"].ToString();
                    danToc.MoTa = dataReader["MoTa"].ToString();
                    danToc.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsdantoc.Add(danToc);
                }
                return dsdantoc;
            }
            catch (Exception e)
            {
                log.Error("Generate DAN TOC", e);
                return null;
            }
        }
    }
}
