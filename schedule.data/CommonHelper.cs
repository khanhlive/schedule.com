using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using schedule.data.Models;

namespace schedule.data
{
    public class CommonHelper
    {
        public static bool isKhoaDuLieu(Hospital data, DateTime dt, string ploaict)
        {
            List<KhoaDL> _lkhoa = new List<KhoaDL>();
            if (_lkhoa.Count > 0)
            {
                System.Windows.Forms.MessageBox.Show("Ngày: " + dt.Date.ToString().Substring(0, 10) + " đã được khóa");
                return true;
            }
            return false;
        }
        public static void SetDoiTuongBHYT()
        {
            Hospital _data = new Hospital();
            var dt = _data.DTBNs.Where(p => p.HTTT == 1).ToList();
            if (dt.Count > 0)
            {
                Common._idDTBHYT = dt.First().IDDTBN;
            }
            else
                Common._idDTBHYT = -1;
        }

        public static bool isWeekend(DateTime dt)
        {
            var thu1 = dt.DayOfWeek;
            int thu = Convert.ToInt32(thu1);
            if (thu == 0)
                return true;
            if (thu == 6)
                return true;
            return false;
        }
    }
}
