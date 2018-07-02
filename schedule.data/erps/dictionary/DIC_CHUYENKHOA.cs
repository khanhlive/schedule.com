namespace schedule.data.erps.dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using schedule.data.enums;
    using schedule.data.helpers;
    public class DIC_CHUYENKHOA : EntityBase<DIC_CHUYENKHOA>
    {
        public DIC_CHUYENKHOA()
        {
            this.StoreGetAll = "GetAllChuyenKhoa";
            this.StoreGetAllActive = "GetChuyenKhoa";
        }

        [ValueMember]
        public int MaChuyenKhoa { get; set; }
        [DisplayMember]
        public string TenChuyenKhoa { get; set; }
        public string TenChiTiet { get; set; }
        public string MaQuyetDinh { get; set; }
        public int Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_CHUYENKHOA chuyenKhoa)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteChuyenKhoa", new string[] { "@MaChuyenKhoa" }, new object[] { chuyenKhoa.MaChuyenKhoa });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Delete CHUYEN KHOA", ex);
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

        public override SqlResultType Insert(DIC_CHUYENKHOA chuyenKhoa)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertChuyenKhoa",
                    new string[] { "@MaChuyenKhoa", "@TenChuyenKhoa", "@TenChiTiet", "@Status", "@MaQuyetDinh" },
                    new object[] { chuyenKhoa.MaChuyenKhoa, chuyenKhoa.TenChuyenKhoa, chuyenKhoa.TenChiTiet, chuyenKhoa.Status, chuyenKhoa.MaQuyetDinh }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Insert CHUYEN KHOA", ex);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_CHUYENKHOA chuyenKhoa)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateChuyenKhoa",
                    new string[] { "@MaChuyenKhoa", "@TenChuyenKhoa", "@TenChiTiet", "@Status", "@MaQuyetDinh" },
                    new object[] { chuyenKhoa.MaChuyenKhoa, chuyenKhoa.TenChuyenKhoa, chuyenKhoa.TenChiTiet, chuyenKhoa.Status, chuyenKhoa.MaQuyetDinh }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Update CHUYEN KHOA", ex);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_CHUYENKHOA> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_CHUYENKHOA> dsChuyenKhoa = new List<DIC_CHUYENKHOA>();
                while (dataReader.Read())
                {
                    DIC_CHUYENKHOA chuyenKhoa = new DIC_CHUYENKHOA();
                    chuyenKhoa.MaChuyenKhoa = Convert.ToInt32(dataReader["MaChuyenKhoa"].ToString());
                    chuyenKhoa.TenChuyenKhoa = dataReader["TenChuyenKhoa"].ToString();
                    chuyenKhoa.TenChiTiet = dataReader["TenChiTiet"].ToString();
                    chuyenKhoa.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    chuyenKhoa.MaQuyetDinh = dataReader["MaQuyetDinh"].ToString();
                    dsChuyenKhoa.Add(chuyenKhoa);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate CHUYEN KHOA", ex);
                return null;
            }
        }
    }
}
