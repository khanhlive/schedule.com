namespace schedule.data.erps.dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using schedule.data.enums;
    using schedule.data.helpers;
    using schedule.data.erps.dictionary;

    public class DIC_DTBN :EntityBase<DIC_DTBN>
    {
        public DIC_DTBN()
        {
            this.StoreGetAllActive = "GetDoiTuongBenhNhan";
            this.StoreGetAll = "GetAllDoiTuongBenhNhan";
        }

        [ValueMember]
        public byte IDDTBN { get; set; }
        [DisplayMember]
        public string TenDTBN { get; set; }
        public string MoTa { get; set; }
        public byte HinhThucThanhToan { get; set; }
        public int Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_DTBN doituongbenhnhan)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteDoiTuongBenhNhan", new string[] { "@IDDTBN" }, new object[] { doituongbenhnhan.IDDTBN });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete DOI TUONG BENH NHAN", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override DIC_DTBN Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_DTBN doituongbenhnhan)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDoiTuongBenhNhan",
                    new string[] { "@IDDTBN", "@TenDTBN", "@MoTa", "@Status", "@HinhThucThanhToan" },
                    new object[] { doituongbenhnhan.IDDTBN, doituongbenhnhan.TenDTBN, doituongbenhnhan.MoTa, doituongbenhnhan.Status, doituongbenhnhan.HinhThucThanhToan });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert DOI TUONG BENH NHAN", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_DTBN doituongbenhnhan)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDoiTuongBenhNhan",
                    new string[] { "@IDDTBN", "@TenDTBN", "@MoTa", "@Status", "@HinhThucThanhToan" },
                    new object[] { doituongbenhnhan.IDDTBN, doituongbenhnhan.TenDTBN, doituongbenhnhan.MoTa, doituongbenhnhan.Status, doituongbenhnhan.HinhThucThanhToan });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update DOI TUONG BENH NHAN", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_DTBN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_DTBN> dsdoituongbenhnhan = new List<DIC_DTBN>();
                while (dataReader.Read())
                {
                    DIC_DTBN doituongbenhnhan = new DIC_DTBN();
                    doituongbenhnhan.IDDTBN = Convert.ToByte(dataReader["IDDTBN"].ToString());
                    doituongbenhnhan.TenDTBN = dataReader["TenDTBN"].ToString();
                    doituongbenhnhan.MoTa = dataReader["MoTa"].ToString();
                    doituongbenhnhan.HinhThucThanhToan = Convert.ToByte(dataReader["HinhThucThanhToan"].ToString());
                    doituongbenhnhan.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsdoituongbenhnhan.Add(doituongbenhnhan);
                }
                dataReader.Close();
                return dsdoituongbenhnhan;
            }
            catch (Exception e)
            {
                log.Error("Generate DOI TUONG BENH NHAN", e);
                return null;
            }
        }
    }
}
