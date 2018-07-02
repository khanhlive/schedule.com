namespace schedule.data.erps.dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using schedule.data.enums;
    using schedule.data.helpers;

    public class DIC_NHACUNGCAP : EntityBase<DIC_NHACUNGCAP>
    {
        public DIC_NHACUNGCAP():base()
        {
            this.StoreGetAll = "GetAllNhaCungCap";
            this.StoreGetAllActive = "GetNhaCungCap";
        }

        public int ID { get; set; }
        [ValueMember]
        public string MaNhaCungCap { get; set; }
        [DisplayMember]
        public string TenNhaCungCap { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string NguoiDaiDien { get; set; }
        public Nullable<int> Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_NHACUNGCAP nhacungcap)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteNhaCungCap", new string[] { "@MaNhaCungCap" }, new object[] { nhacungcap.MaNhaCungCap });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete NHA CUNG CAP", e);
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

        public override SqlResultType Insert(DIC_NHACUNGCAP nhacungcap)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[InsertNhaCungCap]",
                    new string[] { "@MaNhaCungCap", "@TenNhaCungCap", "@DiaChi", "@DienThoai", "@NguoiDaiDien", "@Status" },
                    new object[] { nhacungcap.MaNhaCungCap, nhacungcap.TenNhaCungCap, nhacungcap.DiaChi, nhacungcap.DienThoai, nhacungcap.NguoiDaiDien, nhacungcap.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert NHA CUNG CAP", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_NHACUNGCAP nhacungcap)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateNhaCungCap",
                    new string[] { "@MaNhaCungCap", "@TenNhaCungCap", "@DiaChi", "@DienThoai", "@NguoiDaiDien", "@Status" },
                    new object[] { nhacungcap.MaNhaCungCap, nhacungcap.TenNhaCungCap, nhacungcap.DiaChi, nhacungcap.DienThoai, nhacungcap.NguoiDaiDien, nhacungcap.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update NHA CUNG CAP", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_NHACUNGCAP> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_NHACUNGCAP> dsnhacungcap = new List<DIC_NHACUNGCAP>();
                while (dataReader.Read())
                {
                    DIC_NHACUNGCAP nhacungcap = new DIC_NHACUNGCAP();
                    nhacungcap.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    nhacungcap.MaNhaCungCap = dataReader["MaNhaCungCap"].ToString();
                    nhacungcap.TenNhaCungCap = dataReader["TenNhaCungCap"].ToString();
                    nhacungcap.DiaChi = dataReader["DiaChi"].ToString();
                    nhacungcap.DienThoai = dataReader["DienThoai"].ToString();
                    nhacungcap.NguoiDaiDien = dataReader["NguoiDaiDien"].ToString();
                    nhacungcap.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsnhacungcap.Add(nhacungcap);
                }
                return dsnhacungcap;
            }
            catch (Exception e)
            {
                log.Error("Generate NHA CUNG CAP", e);
                return null;
            }
        }
    }
}
