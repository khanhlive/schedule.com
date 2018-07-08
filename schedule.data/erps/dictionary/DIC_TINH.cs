using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;
using schedule.data.erps.dictionary;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace schedule.data.erps.dictionary
{

    public class DIC_TINH : EntityBase<DIC_TINH>
    {

        public DIC_TINH()
        {
            this.StoreGetAllActive = "GetTinhThanh";
            this.StoreGetAll = "GetAllTinhThanh";
        }

        #region Properties
        [ValueMember]
        [Required(ErrorMessage ="Chưa nhập mã tỉnh")]
        [Display(Name ="Mã tỉnh")]
        [StringLength(10,MinimumLength =2,ErrorMessage ="Chuỗi ký tự phải có độ dài từ 3-10 ký tự.")]
        [RegularExpression("^([0-9A-Z]|_){1,10}$",ErrorMessage ="Chỉ chứa chứ số, chứ cái, gạch dưới và không chứa chữ có dấu.")]
        public string MaTinh { get; set; }
        [DisplayMember]
        [Required(ErrorMessage = "Chưa nhập tên tỉnh")]
        [Display(Name = "Tên tỉnh")]
        [StringLength(100,ErrorMessage ="Chứa tối đa 100 ký tự")]
        public string TenTinh { get; set; }
        [Required(ErrorMessage = "Chưa nhập cấp")]
        [StringLength(250, ErrorMessage = "Chứa tối đa 250 ký tự")]
        [Display(Name = "Cấp")]
        public string Cap { get; set; }
        [Required(ErrorMessage = "Chưa nhập trạng thái")]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
        #endregion

        #region Method
        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public IEnumerable<DIC_TINH> GetFilter(string key,string cap,string status)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                string query = string.Format("FilterTinhThanh");
                SqlDataReader dataReader = this.sqlHelper.ExecuteReader(query, new string[] { "@key", "@cap", "@status" }, new object[] { key, cap, status });
                return this.DataReaderToList(dataReader);
            }
            catch (Exception ex)
            {
                log.Error("GetFilter DANH MUC TINH THANH", ex);
                return null;
            }
        }

        public override SqlResultType Delete(DIC_TINH tinhthanh)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteTinhThanh", new string[] { "@MaTinh" }, new object[] { tinhthanh.MaTinh });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Delete DANH MUC TINH THANH", ex);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override DIC_TINH Get(object key)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.Text;
                string query = string.Format("SELECT * FROM DIC_TINH AS dt WHERE dt.MaTinh=@MaTinh");
                SqlDataReader dataReader = this.sqlHelper.ExecuteReader(query, new string[] { "@MaTinh" }, new object[] { key });
                DIC_TINH tinhthanh = null;
                if (dataReader.Read()) {
                    tinhthanh = new DIC_TINH();
                    tinhthanh.MaTinh = dataReader["MaTinh"].ToString();
                    tinhthanh.TenTinh = dataReader["TenTinh"].ToString();
                    tinhthanh.Cap = dataReader["Cap"].ToString();
                    tinhthanh.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                }
                return tinhthanh;
            }
            catch (Exception ex)
            {
                log.Error("Update DANH MUC TINH THANH", ex);
                return null;
            }
        }

        public override SqlResultType Insert()
        {
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_TINH tinhthanh)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertTinhThanh",
                    new string[] { "@MaTinh", "@TenTinh", "@Status","@Cap" },
                    new object[] { tinhthanh.MaTinh, tinhthanh.TenTinh, tinhthanh.Status,tinhthanh.Cap }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Insert DANH MUC TINH THANH", ex);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_TINH tinhthanh)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateTinhThanh",
                    new string[] { "@MaTinh", "@TenTinh", "@Status","@Cap" },
                    new object[] { tinhthanh.MaTinh, tinhthanh.TenTinh, tinhthanh.Status, tinhthanh.Cap }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Update DANH MUC TINH THANH", ex);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_TINH> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_TINH> dsChuyenKhoa = new List<DIC_TINH>();
                while (dataReader.Read())
                {
                    DIC_TINH tinhthanh = new DIC_TINH();
                    tinhthanh.MaTinh = dataReader["MaTinh"].ToString();
                    tinhthanh.TenTinh = dataReader["TenTinh"].ToString();
                    tinhthanh.Cap = dataReader["Cap"].ToString();
                    tinhthanh.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsChuyenKhoa.Add(tinhthanh);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate DANH MUC TINH THANH", ex);
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetCaps(int id=1)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Value = "1", Text = "Thành phố Trung ương", Selected = id == 1 });
            selectListItems.Add(new SelectListItem { Value = "2", Text = "Tỉnh", Selected = id == 2 });
            selectListItems.Add(new SelectListItem { Value = "3", Text = "Cơ quan", Selected = id == 3 });
            return selectListItems;
        }
        public string GetCapById(string id)
        {
            return id == "1" ? "Thành phố Trung ương" : id == "2" ? "Tỉnh" : id == "3" ? "Cơ quan" : "";
        }
        #endregion
    }
}
