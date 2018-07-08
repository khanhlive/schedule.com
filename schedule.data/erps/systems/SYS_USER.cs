using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.systems
{
    public class SYS_USER : EntityBase<SYS_USER>
    {
        #region Properties


        public int UserID { get; set; } //(int, not null)
        public int EmployeeID { get; set; } //(int, not null)
        public string UserName { get; set; } //(nvarchar(50), not null)
        public string FullName { get; set; } //(nvarchar(100), null)
        public string Password { get; set; } //(nvarchar(200), null)
        public DateTime LastLogonTime { get; set; } //(datetime2(7), null)
        public string LastIpLogon { get; set; } //(varchar(50), null)
        public bool IsOnline { get; set; } //(bit, null)
        public string SessionKey { get; set; } //(varchar(250), null)
        public DateTime SessionExpire { get; set; } //(datetime2(7), null)
        public int SID { get; set; } //(int, null)
        public int RoleID { get; set; } //(int, null)
        public bool IsLogin { get; set; } //(bit, null)
        public byte[] Photo { get; set; } //(image, null)
        public bool Inactive { get; set; } //(bit, not null)
        public bool IsSystem { get; set; } //(bit, not null)
        public int EditVersion { get; set; } //(int, not null)


        #endregion

        #region Method


        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(SYS_USER entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override SYS_USER Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(SYS_USER entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(SYS_USER entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<SYS_USER> DataReaderToList(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
