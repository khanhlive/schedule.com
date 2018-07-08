using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.erps.dictionary;
using schedule.data.helpers;

namespace schedule.data.erps.dictionary
{
    public class DIC_CANBO : EntityBase<DIC_CANBO>
    {
        public DIC_CANBO() : base()
        {
            this.StoreGetAll = "GetAllCanBo";
            this.StoreGetAllActive = "";
        }

        [ValueMember]
        public string MaCanBo { get; set; }
        [DisplayMember]
        public string TenCanBo { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public string ChucVu { get; set; }
        public string CapBac { get; set; }
        public string BangCap { get; set; }
        public int MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public string MaDanToc { get; set; }
        public string TenDanToc { get; set; }
        public byte[] Image { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public bool KhoaChungTu { get; set; }

        public IEnumerable<DIC_CANBO> GetByMaPhongBan(int maphongban)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetCanBoByMaPhongBan", new string[] { "@MaPhongBan" }, new object[] { maphongban });
                IEnumerable<DIC_CANBO> dscanbo = this.DataReaderToList(dt);
                return dscanbo;
            }
            catch (Exception e)
            {
                log.Error("GetCANBO by Phongban", e);
                return null;
            }
        }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_CANBO canbo)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteCanBo", new string[] { "@MaCanBo" }, new object[] { canbo.MaCanBo });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete CAN BO", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override DIC_CANBO Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_CANBO canbo)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertCanBo",
                    new string[] { "@MaCanBo", "@TenCanBo", "@NgaySinh", "@GioiTinh", "@ChucVu", "@CapBac", "@BangCap", "@MaDanToc", "@MaPhongBan", "@Image", "@DiaChi", "@SoDienThoai", "@KhoaChungTu" },
                    new object[] { canbo.MaCanBo, canbo.TenCanBo, canbo.NgaySinh, canbo.GioiTinh, canbo.ChucVu, canbo.CapBac, canbo.BangCap, canbo.MaDanToc, canbo.MaPhongBan, canbo.Image ?? new byte[] { }, canbo.DiaChi, canbo.SoDienThoai, canbo.KhoaChungTu });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert CAN BO", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {

            return this.Update(this);
        }

        public override SqlResultType Update(DIC_CANBO canbo)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateCanBo",
                    new string[] { "@MaCanBo", "@TenCanBo", "@NgaySinh", "@GioiTinh", "@ChucVu", "@CapBac", "@BangCap", "@MaDanToc", "@MaPhongBan", "@Image", "@DiaChi", "@SoDienThoai", "@KhoaChungTu" },
                    new object[] { canbo.MaCanBo, canbo.TenCanBo, canbo.NgaySinh, canbo.GioiTinh, canbo.ChucVu, canbo.CapBac, canbo.BangCap, canbo.MaDanToc, canbo.MaPhongBan, canbo.Image ?? new byte[] { }, canbo.DiaChi, canbo.SoDienThoai, canbo.KhoaChungTu });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update CAN BO", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_CANBO> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_CANBO> dscanbo = new List<DIC_CANBO>();
                while (dataReader.Read())
                {
                    try
                    {
                        DIC_CANBO canbo = new DIC_CANBO();
                        canbo.BangCap = dataReader["BangCap"].ToString();
                        canbo.CapBac = dataReader["CapBac"].ToString();
                        canbo.ChucVu = dataReader["ChucVu"].ToString();
                        canbo.DiaChi = dataReader["DiaChi"].ToString();
                        if (dataReader["Image"] != System.DBNull.Value)
                            canbo.Image = (byte[])dataReader["Image"];
                        canbo.GioiTinh = Convert.ToInt32(dataReader["GioiTinh"].ToString());
                        canbo.KhoaChungTu = Convert.ToBoolean(dataReader["KhoaChungTu"].ToString());
                        canbo.MaCanBo = dataReader["MaCanBo"].ToString();
                        canbo.MaPhongBan = Convert.ToInt32(dataReader["MaPhongBan"].ToString());
                        canbo.MaDanToc = dataReader["MaDanToc"].ToString();
                        canbo.SoDienThoai = dataReader["SoDienThoai"].ToString();
                        canbo.TenCanBo = dataReader["TenCanBo"].ToString();
                        canbo.TenPhongBan = dataReader["TenPhongBan"].ToString();
                        canbo.TenDanToc = dataReader["TenDanToc"].ToString();
                        dscanbo.Add(canbo);
                    }
                    catch (Exception ex) { log.Error("Generate CAN BO", ex); }
                }
                return dscanbo;
            }
            catch (Exception e)
            {
                log.Error("Generate CAN BO", e);
                return null;
            }
        }
    }
}
