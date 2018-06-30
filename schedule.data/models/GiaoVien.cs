using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace schedule.data.models
{
    public class GiaoVien : EntityBase
    {
        public int IDGV { get; set; } //(int, not null)
        public int IDMon { get; set; } //(int, null)
        public int ChuyenKhoi { get; set; } //(int, null)
        public string TenGV { get; set; } //(nvarchar(100), null)
        public DateTime NamSinh { get; set; } //(date, null)
        public bool GioiTinh { get; set; } //(bit, null)
        public int SoTiet { get; set; } //(int, null)
        public string SoDT { get; set; } //(nvarchar(20), null)
        public string DiaChi { get; set; } //(nvarchar(100), null)
        public string Username { get; set; } //(nvarchar(100), null)
        public string Password { get; set; } //(nvarchar(100), null)
        public IEnumerable<GiaoVien> GetList()
        {
            using (IDbConnection conn = new SqlConnection(this._ConnectionString))
            {
                return conn.Query<GiaoVien>("SELECT * FROM GIAOVIEN", null, null, true, null, CommandType.Text);
            }
        }
    }

}
