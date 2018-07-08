namespace schedule.data.erps.dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using schedule.data.enums;
    using schedule.data.helpers;
    using schedule.data.erps.dictionary;

    public class DIC_NHOMDICHVU : EntityBase<DIC_NHOMDICHVU>
    {
        public DIC_NHOMDICHVU()
        {
            this.StoreGetAllActive = "GetNhomDichVu";
            this.StoreGetAll = "GetAllNhomDichVu";
        }
        [ValueMember]
        public int MaNhom { get; set; }
        [DisplayMember]
        public string TenNhom { get; set; }
        public string TenNhomChiTiet { get; set; }
        public Nullable<int> BHYT { get; set; }
        public Nullable<int> STT { get; set; }
        public int Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_NHOMDICHVU nhom)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteNhomDichVu", new string[] { "@MaNhom" }, new object[] { nhom.MaNhom });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete NHOM DICH VU", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override DIC_NHOMDICHVU Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_NHOMDICHVU nhom)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[InsertNhomDichVu]",
                    new string[] { "@MaNhom", "@TenNhom", "@Status", "@Stt", "@TenNhomChiTiet", "@Bhyt" },
                    new object[] { nhom.MaNhom, nhom.TenNhom, nhom.Status, nhom.STT, nhom.TenNhomChiTiet, nhom.BHYT ?? -1 });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert NHOM DICH VU", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_NHOMDICHVU nhom)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[UpdateNhomDichVu]",
                    new string[] { "@MaNhom", "@TenNhom", "@Status", "@Stt", "@TenNhomChiTiet", "@Bhyt" },
                    new object[] { nhom.MaNhom, nhom.TenNhom, nhom.Status, nhom.STT, nhom.TenNhomChiTiet, nhom.BHYT ?? -1 });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update NHOM DICH VU", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_NHOMDICHVU> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_NHOMDICHVU> dstieunhom = new List<DIC_NHOMDICHVU>();
                while (dataReader.Read())
                {
                    DIC_NHOMDICHVU dsnhom = new DIC_NHOMDICHVU();
                    dsnhom.TenNhom = dataReader["TenNhom"].ToString();
                    dsnhom.MaNhom = DataConverter.StringToInt(dataReader["MaNhom"].ToString());
                    dsnhom.TenNhomChiTiet = (dataReader["TenNhomChiTiet"].ToString());
                    dsnhom.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsnhom.BHYT = DataConverter.ToInt(dataReader["BHYT"].ToString());
                    dsnhom.STT = DataConverter.ToByte(dataReader["STT"].ToString());

                    dstieunhom.Add(dsnhom);
                }
                return dstieunhom;
            }
            catch (Exception e)
            {
                log.Error("Generate NHOM DICH VU", e);
                return null;
            }
        }
    }
}
