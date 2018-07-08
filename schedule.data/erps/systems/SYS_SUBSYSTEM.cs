using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.systems
{
    public class SYS_SUBSYSTEM : EntityBase<SYS_SUBSYSTEM>
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

        public override SqlResultType Delete(SYS_SUBSYSTEM entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override SYS_SUBSYSTEM Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(SYS_SUBSYSTEM entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(SYS_SUBSYSTEM entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SYS_SUBSYSTEM> GetSubSystemBySystemId(string systemId)
        {
            string query = string.Format(@"SELECT ss.SubSystemID,ss.SubSystemCode,ss.SubSystemName,ss.[Description],ss.ParentID,ss.SortOrder,ss.SystemType,ss.EditVersion,ss.GroupSystem_ID FROM SYS_SUBSYSTEM AS ss WHERE ss.GroupSystem_ID = @SystemId ORDER BY ss.GroupSystem_ID,ss.ParentID,ss.SortOrder");
            if (!string.IsNullOrEmpty(query) && !string.IsNullOrWhiteSpace(query))
            {
                this.CreateConnection();
                try
                {
                    this.sqlHelper.CommandType = CommandType.Text;
                    SqlDataReader dt = this.sqlHelper.ExecuteReader(query, new string[] { "@SystemId" }, new object[] { systemId });
                    return this.DataReaderToList(dt);
                }
                catch (Exception e)
                {
                    this.sqlHelper.Close();
                    log.Error("GetSubSystemBySystemId", e);
                    return null;
                }
            }
            else return null;
        }

        protected override IEnumerable<SYS_SUBSYSTEM> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<SYS_SUBSYSTEM> sys_subsystems = new List<SYS_SUBSYSTEM>();
                while (dataReader.Read())
                {
                    SYS_SUBSYSTEM sys_groupsystem = new SYS_SUBSYSTEM();
                    sys_groupsystem.SubSystemID = DataConverter.StringToInt(dataReader["SubSystemID"].ToString());
                    sys_groupsystem.SubSystemCode = dataReader["SubSystemCode"].ToString();
                    sys_groupsystem.SubSystemName = dataReader["SubSystemName"].ToString();
                    sys_groupsystem.Description = dataReader["Description"].ToString();
                    //sys_groupsystem.Image = dataReader["Image"].ToString();
                    sys_groupsystem.SortOrder = DataConverter.StringToInt(dataReader["SortOrder"].ToString());
                    sys_groupsystem.SystemType = DataConverter.StringToInt(dataReader["SystemType"].ToString());
                    sys_groupsystem.EditVersion = DataConverter.StringToInt(dataReader["EditVersion"].ToString());
                    sys_groupsystem.GroupSystem_ID = DataConverter.StringToInt(dataReader["GroupSystem_ID"].ToString());
                    sys_groupsystem.ParentID = dataReader["ParentID"].ToString();
                    sys_subsystems.Add(sys_groupsystem);
                }
                return sys_subsystems;
            }
            catch (Exception ex)
            {
                log.Error("Generate SYS_SUBSYSTEM", ex);
                return null;
            }
        }

        #endregion
    }
}
