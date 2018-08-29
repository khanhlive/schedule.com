using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using schedule.data.enums;
using schedule.data.helpers;

namespace schedule.data.erps.his
{
    public class DIC_GIOITINH : EntityBase<DIC_GIOITINH>
    {
        #region Properties
        
        public int ID { get; set; } //(int, not null)
        [ValueMember]
        public string Ma { get; set; } //(varchar(10), null)
        [DisplayMember]
        public string Ten { get; set; } //(nvarchar(50), null)

        #endregion

        #region Method

        public override IEnumerable<DIC_GIOITINH> GetAll()
        {
            try
            {
                this.CreateConnection();
                this.sqlHelper.CommandType = CommandType.Text;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("SELECT * FROM DIC_GIOITINH AS dg");
                return this.DataReaderToList(dt);
            }
            catch (Exception e)
            {
                this.sqlHelper.Close();
                log.Error("GetAll GIOI TINH", e);
                return null;
            }
        }

        public override IEnumerable<DIC_GIOITINH> GetAllActive()
        {
            return this.GetAll();
        }

        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(DIC_GIOITINH entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override DIC_GIOITINH Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(DIC_GIOITINH entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(DIC_GIOITINH entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<DIC_GIOITINH> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_GIOITINH> gioitinhs = new List<DIC_GIOITINH>();
                while (dataReader.Read())
                {
                    DIC_GIOITINH gioitinh = new DIC_GIOITINH();
                    gioitinh.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    gioitinh.Ma = dataReader["Ma"].ToString();
                    gioitinh.Ten= dataReader["Ten"].ToString();
                    gioitinhs.Add(gioitinh);
                }
                return gioitinhs;
            }
            catch (Exception ex)
            {
                log.Error("Generate DANH MUC GIOITINH", ex);
                return null;
            }
        }
        #endregion
    }
}
