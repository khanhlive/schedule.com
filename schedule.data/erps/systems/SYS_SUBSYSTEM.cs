using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
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
        public string Icon { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
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
            string query = string.Format(@"SELECT ss.SubSystemID,ss.SubSystemCode,ss.SubSystemName,ss.[Description],ss.ParentID,ss.SortOrder,ss.SystemType,ss.EditVersion,ss.GroupSystem_ID,ss.Icon,ss.[Url],ss.Area,ss.Controller,ss.ActionName FROM SYS_SUBSYSTEM AS ss WHERE ss.GroupSystem_ID = @SystemId OR ss.GroupSystem_ID=0 ORDER BY ss.GroupSystem_ID,ss.ParentID,ss.SortOrder");
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
                    sys_groupsystem.SubSystemID = DataConverter.StringToInt(dataReader["SubSystemID"]);
                    sys_groupsystem.SubSystemCode = DataConverter.ToString(dataReader["SubSystemCode"]);
                    sys_groupsystem.SubSystemName = DataConverter.ToString(dataReader["SubSystemName"]);
                    sys_groupsystem.Description = DataConverter.ToString(dataReader["Description"]);
                    sys_groupsystem.Icon = DataConverter.ToString(dataReader["Icon"]);
                    sys_groupsystem.Image = DataConverter.ToString(dataReader["Image"]);
                    sys_groupsystem.Url = DataConverter.ToString(dataReader["Url"]);
                    sys_groupsystem.Area = DataConverter.ToString(dataReader["Area"]);
                    sys_groupsystem.Controller = DataConverter.ToString(dataReader["Controller"]);
                    sys_groupsystem.ActionName = DataConverter.ToString(dataReader["ActionName"]);
                    sys_groupsystem.SortOrder = DataConverter.StringToInt(dataReader["SortOrder"]);
                    sys_groupsystem.SystemType = DataConverter.StringToInt(dataReader["SystemType"]);
                    sys_groupsystem.EditVersion = DataConverter.StringToInt(dataReader["EditVersion"]);
                    sys_groupsystem.GroupSystem_ID = DataConverter.StringToInt(dataReader["GroupSystem_ID"]);
                    sys_groupsystem.ParentID = DataConverter.ToString(dataReader["ParentID"]);
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

        public string GetUrl()
        {
            if (this.Url != null && this.Url != string.Empty)
                return this.Url;
            else if (this.Controller != null && this.ActionName != null && this.Controller != "" && this.ActionName != "")
            {
                UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                string url = urlHelper.Action(this.ActionName, this.Controller, new { area = this.Area ?? "" });
                return url;
            }
            else
                return string.Format("javascript:void(0);");

        }
        #endregion
    }
}
