using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.systems
{
    public class SYS_ROLE_PERMISSION_MAPING : EntityBase<SYS_ROLE_PERMISSION_MAPING>
    {
        #region Properties

        public int ID { get; set; } //(int, not null)
        public int SubSystem_ID { get; set; } //(int, not null)
        public int RoleID { get; set; } //(int, null)
        public int AllowAll { get; set; } //(int, not null)
        public int AllowView { get; set; } //(int, not null)
        public int AllowAdd { get; set; } //(int, not null)
        public int AllowEdit { get; set; } //(int, not null)
        public int AllowDelete { get; set; } //(int, not null)
        public int AllowApproval { get; set; } //(int, not null)
        public int AllowDisapproval { get; set; } //(int, not null)
        public int AllowPrint { get; set; } //(int, not null)
        public int AllowImportExcel { get; set; } //(int, not null)
        public int AllowExportExcel { get; set; } //(int, not null)
        public int AllowViewSubRef { get; set; } //(int, not null)
        public int AllowAddSubRef { get; set; } //(int, not null)
        public int InActive { get; set; } //(int, not null)


        #endregion

        #region Method

        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(SYS_ROLE_PERMISSION_MAPING entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override SYS_ROLE_PERMISSION_MAPING Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(SYS_ROLE_PERMISSION_MAPING entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(SYS_ROLE_PERMISSION_MAPING entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<SYS_ROLE_PERMISSION_MAPING> DataReaderToList(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
