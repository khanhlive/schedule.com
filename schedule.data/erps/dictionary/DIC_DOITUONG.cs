namespace schedule.data.erps.dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using schedule.data.enums;
    using schedule.data.helpers;
    using schedule.data.erps.dictionary;

    public class DIC_DOITUONG : EntityBase<DIC_DOITUONG>
    {
        public DIC_DOITUONG()
        {
            this.StoreGetAll = "GetAllDoiTuong";
            this.StoreGetAllActive = "GetDoiTuong";
        }
        [ValueMember]
        public string MaDoiTuong { get; set; }
        [DisplayMember]
        public string TenDoiTuong { get; set; }
        public string NhomDoiTuong { get; set; }
        public Nullable<int> VanChuyen { get; set; }
        
        public Nullable<int> MaMuc { get; set; }
        public Nullable<int> MucCu { get; set; }
        public Nullable<int> Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_DOITUONG doituong)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteDoiTuong", new string[] { "@MaDoiTuong" }, new object[] { doituong.MaDoiTuong });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete DOI TUONG", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override DIC_DOITUONG Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            return this.Delete(this);
        }

        public override SqlResultType Insert(DIC_DOITUONG doituong)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDoiTuong",
                    new string[] { "@MaDoiTuong", "@TenDoiTuong", "@NhomDoiTuong", "@MaMuc", "@MucCu", "@Status", "@VanChuyen" },
                    new object[] { doituong.MaDoiTuong, doituong.TenDoiTuong, doituong.NhomDoiTuong, doituong.MaMuc, doituong.MucCu, doituong.Status, doituong.VanChuyen });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert DOI TUONG", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Delete(this);
        }

        public override SqlResultType Update(DIC_DOITUONG doituong)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDoiTuong",
                    new string[] { "@MaDoiTuong", "@TenDoiTuong", "@NhomDoiTuong", "@MaMuc", "@MucCu", "@Status", "@VanChuyen" },
                    new object[] { doituong.MaDoiTuong, doituong.TenDoiTuong, doituong.NhomDoiTuong, doituong.MaMuc, doituong.MucCu, doituong.Status, doituong.VanChuyen });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update DOI TUONG", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_DOITUONG> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_DOITUONG> dsdoituong = new List<DIC_DOITUONG>();
                while (dataReader.Read())
                {
                    DIC_DOITUONG doituong = new DIC_DOITUONG();
                    doituong.MaDoiTuong = dataReader["MaDoiTuong"].ToString();
                    doituong.TenDoiTuong = dataReader["TenDoiTuong"].ToString();
                    doituong.NhomDoiTuong = dataReader["NhomDoiTuong"].ToString();
                    doituong.MaMuc = DataConverter.StringToInt(dataReader["MaMuc"].ToString());
                    doituong.MucCu = DataConverter.ToInt(dataReader["MucCu"].ToString());
                    doituong.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    doituong.VanChuyen = DataConverter.StringToInt(dataReader["VanChuyen"].ToString());

                    dsdoituong.Add(doituong);
                }
                return dsdoituong;
            }
            catch (Exception e)
            {
                log.Error("Generate DOI TUONG", e);
                return null;
            }
        }
    }
}
