using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.systems
{
    public class SYS_SUBSYSTEM : EntityBase<SYS_USER>
    {
        #region Properties

        public int SubSystemID { get; set; } //(int, not null)
        public string SubSystemCode { get; set; } //(varchar(255), not null)
        public string SubSystemName { get; set; } //(nvarchar(150), null)
        public string Description { get; set; } //(nvarchar(150), null)
        public string ParentID { get; set; } //(nvarchar(255), null)
        public int SortOrder { get; set; } //(int, null)
        public int SystemType { get; set; } //(int, null)
        public int EditVersion { get; set; } //(int, not null)
        public int GroupSystem_ID { get; set; } //(int, null)



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

        public override SqlResultType Get(object key)
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
