namespace schedule.data.erps.dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using schedule.data.enums;
    using schedule.data.helpers;
    public class DIC_PHANLOAIPHONGBAN :EntityBase<DIC_PHANLOAIPHONGBAN>
    {
        public DIC_PHANLOAIPHONGBAN()
        {
            this.StoreGetAll = "GetAllPhanLoaiPhongBan";
            this.StoreGetAllActive = "GetPhanLoaiPhongBan";
        }
        [ValueMember]
        public int ID { get; set; }
        [DisplayMember]
        public string PhanLoai { get; set; }
        public bool Status { get; set; }

        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(DIC_PHANLOAIPHONGBAN entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override DIC_PHANLOAIPHONGBAN Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(DIC_PHANLOAIPHONGBAN entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(DIC_PHANLOAIPHONGBAN entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<DIC_PHANLOAIPHONGBAN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_PHANLOAIPHONGBAN> dsphanloaiphongban = new List<DIC_PHANLOAIPHONGBAN>();
                while (dataReader.Read())
                {
                    DIC_PHANLOAIPHONGBAN phanloaiphongban = new DIC_PHANLOAIPHONGBAN();
                    phanloaiphongban.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    phanloaiphongban.PhanLoai = dataReader["PhanLoai"].ToString();
                    phanloaiphongban.Status = Convert.ToBoolean(dataReader["Status"].ToString());

                    dsphanloaiphongban.Add(phanloaiphongban);
                }
                return dsphanloaiphongban;
            }
            catch (Exception e)
            {
                log.Error("Generate PHAN LOAI PHONG BAN", e);
                return null;
            }
        }
    }
}
