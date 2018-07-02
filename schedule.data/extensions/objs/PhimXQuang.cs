using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.data.helpers.objs
{
    public class PhimXQuang_Size
    {
        int idCoPhim;

        public int IdCoPhim
        {
            get { return idCoPhim; }
            set { idCoPhim = value; }
        }
        string coPhim;

        public string CoPhim
        {
            get { return coPhim; }
            set { coPhim = value; }
        }
        public static List<PhimXQuang_Size> Init
        {
            get
            {
                List<PhimXQuang_Size> _lCoPhim = new List<PhimXQuang_Size>();
                if (Common.MaBV == "30009")
                    _lCoPhim.Add(new PhimXQuang_Size { idCoPhim = 0, CoPhim = "8/10" });
                else
                    _lCoPhim.Add(new PhimXQuang_Size { idCoPhim = 0, CoPhim = "Không XĐ" });
                _lCoPhim.Add(new PhimXQuang_Size { idCoPhim = 1, CoPhim = "13/18" });
                _lCoPhim.Add(new PhimXQuang_Size { idCoPhim = 2, CoPhim = "18/24" });
                _lCoPhim.Add(new PhimXQuang_Size { idCoPhim = 3, CoPhim = "24/30" });
                _lCoPhim.Add(new PhimXQuang_Size { idCoPhim = 4, CoPhim = "30/40" });
                return _lCoPhim;
            }
        }
    }
}
