namespace schedule.data.erps.dictionary
{
    using schedule.data.enums;
    using schedule.data.helpers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class DIC_BENHVIEN : EntityBase<DIC_BENHVIEN>
    {
        public DIC_BENHVIEN():base()
        {
            this.StoreGetAll = "GetAllBenhVien";
            this.StoreGetAllActive = "GetBenhVien";
        }

        public int ID { get; set; }
        [ValueMember]
        public string MaBenhVien { get; set; }
        public string MaChuQuan { get; set; }
        [DisplayMember]
        public string TenBenhVien { get; set; }
        public string TuyenBenhVien { get; set; }
        public int HangBenhVien { get; set; }
        public string MaHuyen { get; set; }
        public string TenHuyen { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string DiaChi { get; set; }
        public bool Connect { get; set; }
        public int Status { get; set; }

        public IEnumerable<DIC_BENHVIEN> GetAllBenhVienByHuyen(string mahuyen)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetBenhVienByMaHuyen", new string[] { "@MaHuyen" }, new object[] { mahuyen });
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByHuyen DANH MUC DIC BENHVIEN", ex);
                return null;
            }
        }

        public IEnumerable<DIC_BENHVIEN> GetAllBenhVienByTinh(string matinh)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetBenhVienByMaTinh", new string[] { "@MaTinh" }, new object[] { matinh });
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByHuyen DANH MUC DIC BENHVIEN", ex);
                return null;
            }

        }

        public IEnumerable<DIC_BENHVIEN> GetAllBenhVienByConnect()
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetBenhVienByConnect");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByHuyen DANH MUC DIC BENHVIEN", ex);
                return null;
            }

        }

        public override SqlResultType Insert()
        {
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_BENHVIEN benhvien)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertBenhVien",
                    new string[] { "@MaBenhVien", "@MaTinh", "@MaHuyen", "@MaChuQuan", "@TenBenhVien", "@TuyenBenhVien", "@HangBenhVien", "@DiaChi", "@Connect", "@Status" },
                    new object[] { benhvien.MaBenhVien, benhvien.MaTinh, benhvien.MaHuyen, benhvien.MaChuQuan, benhvien.TenBenhVien, benhvien.TuyenBenhVien, benhvien.HangBenhVien, benhvien.DiaChi, benhvien.Connect, benhvien.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert BENH VIEN", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_BENHVIEN benhvien)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateBenhVien",
                    new string[] { "@MaBenhVien", "@MaTinh", "@MaHuyen", "@MaChuQuan", "@TenBenhVien", "@TuyenBenhVien", "@HangBenhVien", "@DiaChi", "@Connect", "@Status" },
                    new object[] { benhvien.MaBenhVien, benhvien.MaTinh, benhvien.MaHuyen, benhvien.MaChuQuan, benhvien.TenBenhVien, benhvien.TuyenBenhVien, benhvien.HangBenhVien, benhvien.DiaChi, benhvien.Connect, benhvien.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update BENH VIEN", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_BENHVIEN entity)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteBenhVien", new string[] { "@MaBenhVien" }, new object[] { entity.MaBenhVien });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete BENH VIEN", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override DIC_BENHVIEN Get(object key)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<DIC_BENHVIEN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_BENHVIEN> dsChuyenKhoa = new List<DIC_BENHVIEN>();
                while (dataReader.Read())
                {
                    DIC_BENHVIEN benhvien = new DIC_BENHVIEN();
                    benhvien.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    benhvien.MaBenhVien = dataReader["MaBenhVien"].ToString();
                    benhvien.MaHuyen = dataReader["MaHuyen"].ToString();
                    benhvien.TenBenhVien = dataReader["TenBenhVien"].ToString();
                    benhvien.MaChuQuan = dataReader["MaChuQuan"].ToString();
                    benhvien.TenHuyen = dataReader["TenHuyen"].ToString();
                    benhvien.MaTinh = dataReader["MaTinh"].ToString();
                    benhvien.TenTinh = dataReader["TenTinh"].ToString();
                    benhvien.TuyenBenhVien = dataReader["TuyenBenhVien"].ToString();
                    benhvien.HangBenhVien = DataConverter.StringToInt(dataReader["HangBenhVien"].ToString());
                    benhvien.DiaChi = dataReader["DiaChi"].ToString();
                    benhvien.Connect = Convert.ToBoolean(dataReader["Connect"].ToString());
                    benhvien.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsChuyenKhoa.Add(benhvien);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate DANH MUC DIC BENHVIEN", ex);
                return null;
            }
        }
    }
}
