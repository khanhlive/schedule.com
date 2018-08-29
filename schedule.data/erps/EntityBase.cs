using Dapper;
using schedule.data.enums;
using schedule.data.helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace schedule.data.erps
{
    public abstract class EntityBase<T> : DapperRepository<T> where T : class
    {
        #region Name StoreProcedure
        protected string StoreGetAll { get; set; }
        protected string StoreGetAllActive { get; set; }
        #endregion

        public EntityBase() : base() { }
        public EntityBase(SqlHelper sqlHelper) : base(sqlHelper) { }

        public virtual IEnumerable<T> GetAll()
        {
            if (!string.IsNullOrEmpty(StoreGetAll) && !string.IsNullOrWhiteSpace(StoreGetAll))
            {
                CreateConnection();
                try
                {
                    sqlHelper.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dt = sqlHelper.ExecuteReader(StoreGetAll);
                    return DataReaderToList(dt);
                }
                catch (Exception e)
                {
                    sqlHelper.Close();
                    log.Error("GetAll", e);
                    return null;
                }
            }
            else return null;
        }
        public virtual IEnumerable<T> GetAllActive()
        {
            if (!string.IsNullOrEmpty(StoreGetAllActive) && !string.IsNullOrWhiteSpace(StoreGetAllActive))
            {
                CreateConnection();
                try
                {
                    sqlHelper.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dt = sqlHelper.ExecuteReader(StoreGetAllActive);
                    return DataReaderToList(dt);
                }
                catch (Exception e)
                {
                    sqlHelper.Close();
                    log.Error("GetAllActive", e);
                    return null;
                }
            }
            else return null;
        }
        public abstract SqlResultType Insert();
        public abstract SqlResultType Insert(T entity);
        public abstract SqlResultType Update();
        public abstract SqlResultType Update(T entity);
        public abstract SqlResultType Delete();
        public abstract SqlResultType Delete(T entity);
        public abstract SqlResultType Exsist(object key);
        public abstract T Get(object key);

        protected abstract IEnumerable<T> DataReaderToList(SqlDataReader dataReader);

        protected string GetValueMember
        {
            get
            {
                PropertyInfo keyProperty = null;
                foreach (PropertyInfo pi in typeof(T).GetProperties())
                {
                    object[] attrs = pi.GetCustomAttributes(typeof(ValueMemberAttribute), false);
                    if (attrs != null && attrs.Length == 1)
                    {
                        keyProperty = pi;
                        break;
                    }
                }

                return keyProperty == null ? string.Empty : keyProperty.Name;
            }
        }

        protected string GetDisplayMember
        {
            get
            {
                PropertyInfo displayrProperty = null;
                foreach (PropertyInfo pi in typeof(T).GetProperties())
                {
                    object[] attrs = pi.GetCustomAttributes(typeof(DisplayMemberAttribute), false);
                    if (attrs != null && attrs.Length == 1)
                    {
                        displayrProperty = pi;
                        break;
                    }
                }

                return displayrProperty == null ? string.Empty : displayrProperty.Name;
            }
        }

        protected SqlResultType GetResult(int result)
        {
            switch (result)
            {
                case -2:
                    return SqlResultType.NotExisted;
                case -1:
                    return SqlResultType.Existed;
                case 0:
                    return SqlResultType.Failed;
                case 1:
                    return SqlResultType.OK;
                default:
                    return SqlResultType.Failed;
            }
        }

    }


    public abstract class DapperRepository<T> : AppRepository where T : class
    {
        #region Constructors
        public DapperRepository() : base() { }
        public DapperRepository(SqlHelper sqlHelper) : base(sqlHelper) { }
        #endregion

        #region Dapper

        public virtual IEnumerable<T> GetListByDapper(string query, string[] paramsName = null, object[] paramsValue = null, CommandType commandType = CommandType.Text)
        {
            return base.GetListByDapper<T>(query, paramsName, paramsValue, commandType);
        }
        public virtual IEnumerable<T> GetListByDapper(string query, CommandType commandType = CommandType.Text)
        {
            return GetListByDapper(query, null, null, commandType);
        }
        public virtual IEnumerable<T> GetListByDapper(string query)
        {
            return GetListByDapper(query, CommandType.Text);
        }
        public virtual T GetSingleByDapper(string query, string[] paramsName = null, object[] paramsValue = null, CommandType commandType = CommandType.Text)
        {
            return base.GetListByDapper<T>(query, paramsName, paramsValue, commandType).FirstOrDefault();
        }
        public virtual T GetSingleByDapper(string query, CommandType commandType = CommandType.Text)
        {
            return GetSingleByDapper(query, null, null, commandType);
        }
        public virtual T GetSingleByDapper(string query)
        {
            return GetSingleByDapper(query, CommandType.Text);
        }

        #endregion
    }

    public abstract class AppRepository : IDisposable
    {
        #region Constructors
        public AppRepository()
        {
            sqlHelper = new SqlHelper();
            sqlHelper.Error += new SqlHelper.ErrorEventHander(EventError_Hander);
        }
        public AppRepository(SqlHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper;
            this.sqlHelper.Error += new SqlHelper.ErrorEventHander(EventError_Hander);
        }
        #endregion

        #region Properties
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected SqlHelper sqlHelper;
        #endregion

        #region Events
        protected virtual void EventError_Hander(object sender, SqlHelperException e)
        {
            log.Error("SqlException: " + e.Message, e);
        }
        #endregion

        #region Methods
        protected void CreateConnection()
        {
            if (sqlHelper == null)
            {
                sqlHelper = new SqlHelper();
                sqlHelper.Error += new SqlHelper.ErrorEventHander(EventError_Hander);
            }
        }
        public void Dispose()
        {
            sqlHelper = null;
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Dapper
        public virtual IEnumerable<T> GetListByDapper<T>(string query, string[] paramsName = null, object[] paramsValue = null, CommandType commandType = CommandType.Text)
        {
            if (!CheckNullEmptyWhiteSpaceString(sqlHelper.ConnectionString))
            {
                if ((paramsName != null && paramsValue != null) || (paramsName == null && paramsValue == null))
                {
                    using (IDbConnection dbConnection = new SqlConnection(sqlHelper.ConnectionString))
                    {
                        dbConnection.Open();
                        if (paramsValue != null && paramsName != null)
                        {
                            if (paramsValue.Length != paramsName.Length)
                            {
                                throw new Exception(string.Format("Số lượng có trong \"paramsName({0})\" và \"paramsValue{1}\" không bằng nhau", paramsName.Length, paramsValue.Length));
                            }
                            else
                            {
                                DynamicParameters parameters = new DynamicParameters();
                                for (int i = 0; i < paramsValue.Length; i++)
                                {
                                    parameters.Add(paramsName[i], paramsValue[i]);
                                }
                                return dbConnection.Query<T>(query, parameters, null, true, null, commandType);
                            }
                        }
                        else
                        {
                            return dbConnection.Query<T>(query, null, null, true, null, commandType);
                        }
                    }
                }
                else if (paramsValue == null)
                {
                    throw new NullReferenceException("paramsValue == NULL and paramsName != NULL");
                }
                else
                {
                    throw new NullReferenceException("paramsName == NULL and paramsValue != NULL");
                }

            }
            else
                throw new NullReferenceException("Connection String is null.");
        }
        private bool CheckNullEmptyWhiteSpaceString(string inputString)
        {
            if (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString))
                return true;
            else return false;
        }
        public virtual IEnumerable<T> GetListByDapper<T>(string query, CommandType commandType = CommandType.Text)
        {
            try
            {
                return GetListByDapper<T>(query, null, null, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual IEnumerable<T> GetListByDapper<T>(string query)
        {
            try
            {
                return GetListByDapper<T>(query, null, null, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected SqlConnection GetSqlConnection()
        {
            if (sqlHelper == null)
            {
                CreateConnection();
            }
            return new SqlConnection(sqlHelper.ConnectionString);
        }


        #endregion
    }
}
