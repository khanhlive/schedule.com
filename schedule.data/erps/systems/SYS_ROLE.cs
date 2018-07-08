using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.systems
{
    public class SYS_ROLE : EntityBase<SYS_ROLE>
    {
        #region Properties

        public int RoleID { get; set; } //(int, not null)
        public string RoleCode { get; set; } //(nvarchar(20), null)
        public string RoleName { get; set; } //(nvarchar(128), null)
        public string Description { get; set; } //(nvarchar(150), null)
        public bool IsSystem { get; set; } //(bit, not null)
        public int EditVersion { get; set; } //(int, not null)


        #endregion

        #region Method

        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(SYS_ROLE entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override SYS_ROLE Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(SYS_ROLE entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(SYS_ROLE entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<SYS_ROLE> DataReaderToList(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
