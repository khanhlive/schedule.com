namespace schedule.data.erps.dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using schedule.data.enums;
    using schedule.data.helpers;
    using schedule.data.erps.dictionary;
    using Dapper;
    using System.Linq;
    public class DIC_ICD10 : EntityBase<DIC_ICD10>
    {
        public DIC_ICD10():base()
        {
            this.StoreGetAllActive = "GetICD10";
            this.StoreGetAll = "GetAllICD10";
        }

        public int ID { get; set; }
        [ValueMember]
        public string MaICD { get; set; }
        [DisplayMember]
        public string TenICD { get; set; }
        
        public string MaChuongBenh { get; set; }
        
        public string TenChuongBenh { get; set; }
        
        public string TenWHOe { get; set; }
        
        public string TenWHO { get; set; }

        public int? IDCB { get; set; }

        public int? ID_MBICD { get; set; }
        
        public string TenICD_YHCT { get; set; }
        
        public string MaICD10 { get; set; }
        public int Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_ICD10 icd10)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteICD10", new string[] { "@ID" }, new object[] { icd10.ID });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete ICD10", e);
                return SqlResultType.Exception;
            }
        }
        public DataTable GetList()
        {
            return this.sqlHelper.ExecuteDataTable(this.StoreGetAll);
        }
        public IEnumerable<DIC_ICD10> GetByDapper()
        {
            using (IDbConnection dbConnection = new SqlConnection(this.sqlHelper.ConnectionString))
            {
                IEnumerable<DIC_ICD10> icds = dbConnection.Query<DIC_ICD10>(this.StoreGetAll, commandType: CommandType.StoredProcedure).ToList();
                return icds;
            }
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
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_ICD10 icd10)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertICD10",
                    new string[] { "@MaICD", "@TenICD", "@Status", "@MaChuongBenh", "@TenChuongBenh", "@TenWHO", "@TenWHOe" },
                    new object[] { icd10.MaICD, icd10.TenICD, icd10.Status, icd10.MaChuongBenh, icd10.TenChuongBenh, icd10.TenWHO, icd10.TenWHOe });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert ICD10", e);
                return SqlResultType.Exception;
            }
        }

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_ICD10 icd10)
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateICD10",
                    new string[] { "@MaICD", "@TenICD", "@Status", "@MaChuongBenh", "@TenChuongBenh", "@TenWHO", "@TenWHOe" },
                    new object[] { icd10.MaICD, icd10.TenICD, icd10.Status, icd10.MaChuongBenh, icd10.TenChuongBenh, icd10.TenWHO, icd10.TenWHOe });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update ICD10", e);
                return SqlResultType.Exception;
            }
        }

        protected override IEnumerable<DIC_ICD10> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_ICD10> data = new List<DIC_ICD10>();
                while (dataReader.Read())
                {
                    DIC_ICD10 icd10 = new DIC_ICD10();
                    icd10.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    icd10.MaICD = dataReader["MaICD"].ToString();
                    icd10.TenICD = dataReader["TenICD"].ToString();
                    icd10.MaChuongBenh = (dataReader["MaChuongBenh"].ToString());
                    icd10.TenChuongBenh = (dataReader["TenChuongBenh"].ToString());
                    icd10.TenWHO = dataReader["TenWHO"].ToString();
                    icd10.TenWHOe = dataReader["TenWHOe"].ToString();
                    icd10.Status = DataConverter.StringToInt(dataReader["Status"].ToString());

                    data.Add(icd10);
                }
                return data;
            }
            catch (Exception e)
            {
                log.Error("Generate ICD10", e);
                return null;
            }
        }
    }
}
