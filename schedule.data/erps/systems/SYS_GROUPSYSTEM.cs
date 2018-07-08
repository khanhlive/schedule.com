using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;
using Dapper;

namespace schedule.data.erps.systems
{
    public class SYS_GROUPSYSTEM : EntityBase<SYS_GROUPSYSTEM>
    {
        #region Properties

        public int SystemID { get; set; } //(int, not null)
        public string SystemCode { get; set; } //(varchar(10), not null)
        public string SystemName { get; set; } //(nvarchar(150), null)
        public string Description { get; set; } //(nvarchar(150), null)
        public int SortOrder { get; set; } //(int, null)
        public int SystemType { get; set; } //(int, null)
        public int EditVersion { get; set; } //(int, not null)
        public string Image { get; set; } //(nvarchar(500), null)

        #endregion

        #region Method

        public override IEnumerable<SYS_GROUPSYSTEM> GetAll()
        {
            string query = "SELECT * FROM SYS_GROUPSYSTEM AS sg";
            if (!string.IsNullOrEmpty(query) && !string.IsNullOrWhiteSpace(query))
            {
                this.CreateConnection();
                try
                {
                    this.sqlHelper.CommandType = CommandType.Text;
                    SqlDataReader dt = this.sqlHelper.ExecuteReader(query);
                    return this.DataReaderToList(dt);
                }
                catch (Exception e)
                {
                    this.sqlHelper.Close();
                    log.Error("GetAll", e);
                    return null;
                }
            }
            else return null;
        }
        public override IEnumerable<SYS_GROUPSYSTEM> GetAllActive()
        {
            string query = "SELECT * FROM SYS_GROUPSYSTEM AS sg";
            if (!string.IsNullOrEmpty(query) && !string.IsNullOrWhiteSpace(query))
            {
                this.CreateConnection();
                try
                {
                    this.sqlHelper.CommandType = CommandType.Text;
                    SqlDataReader dt = this.sqlHelper.ExecuteReader(query);
                    return this.DataReaderToList(dt);
                }
                catch (Exception e)
                {
                    this.sqlHelper.Close();
                    log.Error("GetAllActive", e);
                    return null;
                }
            }
            else return null;
        }

        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(SYS_GROUPSYSTEM entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override SYS_GROUPSYSTEM Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(SYS_GROUPSYSTEM entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(SYS_GROUPSYSTEM entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<SYS_GROUPSYSTEM> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<SYS_GROUPSYSTEM> dsChuyenKhoa = new List<SYS_GROUPSYSTEM>();
                while (dataReader.Read())
                {
                    SYS_GROUPSYSTEM sys_groupsystem = new SYS_GROUPSYSTEM();
                    sys_groupsystem.SystemID = DataConverter.StringToInt(dataReader["SystemID"].ToString());
                    sys_groupsystem.SystemCode = dataReader["SystemCode"].ToString();
                    sys_groupsystem.SystemName = dataReader["SystemName"].ToString();
                    sys_groupsystem.Description= dataReader["Description"].ToString();
                    sys_groupsystem.Image = dataReader["Image"].ToString();
                    sys_groupsystem.SortOrder = DataConverter.StringToInt(dataReader["SortOrder"].ToString());
                    sys_groupsystem.SystemType = DataConverter.StringToInt(dataReader["SystemType"].ToString());
                    sys_groupsystem.EditVersion = DataConverter.StringToInt(dataReader["EditVersion"].ToString());
                    dsChuyenKhoa.Add(sys_groupsystem);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate SYS_GROUPSYSTEM", ex);
                return null;
            }
        }


        

        #endregion
    }
}
