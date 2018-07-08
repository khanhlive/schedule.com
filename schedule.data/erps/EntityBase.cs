using schedule.data.enums;
using schedule.data.helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace schedule.data.erps
{
    public abstract class EntityBase<T>: IDisposable
    {
        #region Name StoreProcedure
        protected string StoreGetAll { get; set; }
        protected string StoreGetAllActive { get; set; }
        #endregion

        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected SqlHelper sqlHelper;

        public EntityBase()
        {
            
        }

        protected void CreateConnection()
        {
            if (this.sqlHelper==null)
            {
                this.sqlHelper = new SqlHelper();
                this.sqlHelper.Error += new SqlHelper.ErrorEventHander(this.EventError_Hander);
            }
        }
        public virtual IEnumerable<T> GetAll()
        {
            if (!string.IsNullOrEmpty(this.StoreGetAll) && !string.IsNullOrWhiteSpace(this.StoreGetAll))
            {
                this.CreateConnection();
                try
                {
                    this.sqlHelper.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dt = this.sqlHelper.ExecuteReader(this.StoreGetAll);
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

        public virtual IEnumerable<T> GetAllActive()
        {
            if (!string.IsNullOrEmpty(this.StoreGetAllActive) && !string.IsNullOrWhiteSpace(this.StoreGetAllActive))
            {
                this.CreateConnection();
                try
                {
                    this.sqlHelper.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dt = this.sqlHelper.ExecuteReader(this.StoreGetAllActive);
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

        //public void AddComboEdit(ComboBoxEdit combo)
        //{
        //    IEnumerable<T> list = this.GetAll();
        //    foreach (T item in list)
        //    {
        //        combo.Properties.Items.Add(item.GetType().GetProperty(this.GetDisplayMember).GetValue(item, null));
        //    }
        //}

        //public void AddGridLookupEdit(GridLookUpEdit gridlookup)
        //{
        //    IEnumerable<T> list = this.GetAll();
        //    gridlookup.Properties.DataSource = list;
        //    gridlookup.Properties.DisplayMember = this.GetDisplayMember;
        //    gridlookup.Properties.ValueMember = this.GetValueMember;
        //}

        //public void AddLookupEdit(LookUpEdit lookup)
        //{
        //    IEnumerable<T> list = this.GetAll();
        //    lookup.Properties.DataSource = list;
        //    lookup.Properties.DisplayMember = this.GetDisplayMember;
        //    lookup.Properties.ValueMember = this.GetValueMember;
        //    lookup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(this.GetDisplayMember, this.GetDisplayMember));
        //    lookup.Properties.ShowHeader = false;
        //}

        //public void AddRepositoryLookupEdit(RepositoryItemLookUpEdit lookup)
        //{
        //    IEnumerable<T> list = this.GetAll();
        //    lookup.DataSource = list;
        //    lookup.DisplayMember = this.GetDisplayMember;
        //    lookup.ValueMember = this.GetValueMember;
        //    lookup.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(this.GetDisplayMember, this.GetDisplayMember));
        //    lookup.ShowHeader = false;
        //}

        //public void AddCheckBoxListEdit(CheckedListBoxControl checkBoxList)
        //{
        //    IEnumerable<T> list = this.GetAll();
        //    checkBoxList.DataSource = list;
        //    checkBoxList.DisplayMember = this.GetDisplayMember;
        //    checkBoxList.ValueMember = this.GetValueMember;
        //}
        

        //public void AddRepositoryGridLookupEditCode(RepositoryItemGridLookUpEdit gridlookup)
        //{
        //    IEnumerable<T> list = this.GetAll();
        //    gridlookup.DataSource = list;
        //    gridlookup.DisplayMember = this.GetValueMember;
        //    gridlookup.ValueMember = this.GetValueMember;
        //}

        //public void AddRepositoryGridLookupEdit(RepositoryItemGridLookUpEdit gridlookup)
        //{
        //    IEnumerable<T> list = this.GetAll();
        //    gridlookup.DataSource = list;
        //    gridlookup.DisplayMember = this.GetDisplayMember;
        //    gridlookup.ValueMember = this.GetValueMember;
        //}

        public void Dispose()
        {
            this.sqlHelper = null;
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

        private void EventError_Hander(object sender, SqlHelperException e)
        {
            log.Error("SqlException: " + e.Message, e);
        }
    }
}
