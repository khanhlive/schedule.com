using System.Collections.Generic;

namespace schedule.data.helpers.objs
{
    #region Nhóm dịch vụ CV 9324
    public class NhomDV_QD
    {
        private string tennhomcu;

        public string Tennhomcu
        {
            get { return tennhomcu; }
            set { tennhomcu = value; }
        }
        private int iDNhom;
        public int IDNhom
        {
            get { return iDNhom; }
            set { iDNhom = value; }
        }


        private string tenNhom;

        public string TenNhom
        {
            get { return tenNhom; }
            set { tenNhom = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private int sTT;

        public int STT
        {
            get { return sTT; }
            set { sTT = value; }
        }


        private string tenNhomCT;

        public string TenNhomCT
        {
            get { return tenNhomCT; }
            set { tenNhomCT = value; }
        }


        private int bHYT;

        public int BHYT
        {
            get { return bHYT; }
            set { bHYT = value; }
        }

        private static List<NhomDV_QD> _listNhomDV_QD = new List<NhomDV_QD>();
        public static List<NhomDV_QD> SetNhomDV()
        {
            _listNhomDV_QD = new List<NhomDV_QD>();
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 1, TenNhom = "Xét nghiệm", Status = 2, STT = 6, TenNhomCT = "Xét nghiệm", tennhomcu = "Nhóm xét nghiệm" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 2, TenNhom = "Chẩn đoán hình ảnh", Status = 2, STT = 4, TenNhomCT = "Chẩn đoán hình ảnh", tennhomcu = "Nhóm chẩn đoán hình ảnh & TDCN" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 3, TenNhom = "Thăm dò chức năng", Status = 2, STT = 5, TenNhomCT = "Thăm dò chức năng", tennhomcu = "" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 4, TenNhom = "Thuốc trong danh mục BHYT", Status = 1, STT = 10, TenNhomCT = "Thuốc trong danh mục BHYT", tennhomcu = "Nhóm thuốc, dịch truyền" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 5, TenNhom = "Thuốc K, CTG", Status = 1, STT = 15, TenNhomCT = "Thuốc điều trị ung thư, chống thải ghép ngoài danh mục", tennhomcu = "Nhóm thuốc ung thư, chống thải ghép" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 6, TenNhom = "Thuốc thanh toán theo tỷ lệ", Status = 1, STT = 12, TenNhomCT = "Thuốc thanh toán theo tỷ lệ", tennhomcu = "" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 7, TenNhom = "Máu và chế phẩm của máu", Status = 1, STT = 8, TenNhomCT = "Máu và chế phẩm của máu", tennhomcu = "Nhóm máu và chế phẩm của máu" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 8, TenNhom = "Thủ thuật, phẫu thuật", Status = 2, STT = 7, TenNhomCT = "Thủ thuật, phẫu thuật", tennhomcu = "Nhóm phẫu thuật, thủ thuật" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 9, TenNhom = "DVKT thanh toán theo tỷ lệ", Status = 2, STT = 9, TenNhomCT = "DVKT thanh toán theo tỷ lệ", tennhomcu = "Nhóm dịch vụ kỹ thuật cao" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 10, TenNhom = "Vật tư y tế trong danh mục BHYT", Status = 1, STT = 11, TenNhomCT = "Vật tư y tế trong danh mục BHYT", tennhomcu = "Nhóm vật tư y tế tiêu hao" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 11, TenNhom = "VTYT thanh toán theo tỷ lệ", Status = 1, STT = 13, TenNhomCT = "VTYT thanh toán theo tỷ lệ", tennhomcu = "Nhóm vật tư y tế thay thế" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 12, TenNhom = "Vận chuyển", Status = 2, STT = 14, TenNhomCT = "Vận chuyển", tennhomcu = "Chi phí vận chuyển" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 13, TenNhom = "Khám bệnh", Status = 2, STT = 1, TenNhomCT = "Khám bệnh", tennhomcu = "Nhóm tiền công khám" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 14, TenNhom = "Giường điều trị ngoại trú", Status = 2, STT = 2, TenNhomCT = "Giường điều trị ngoại trú", tennhomcu = "" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 15, TenNhom = "Giường điều trị nội trú", Status = 2, STT = 3, TenNhomCT = "Giường điều trị nội trú", tennhomcu = "Nhóm ngày giường" });
            _listNhomDV_QD.Add(new NhomDV_QD { IDNhom = 16, TenNhom = "Tài sản", Status = 2, STT = 16, TenNhomCT = "Tài sản", tennhomcu = "Nhóm tài sản" });
            return _listNhomDV_QD;
        }

    }

    #endregion
}
