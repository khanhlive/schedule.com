using schedule.data.enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace schedule.data.helpers
{
    public class FormatHelper
    {
        public static int Font = 0;
        public static DateTime BeginDate(DateTime dateTime)
        {
            int d = dateTime.Day;
            int m = dateTime.Month;
            int y = dateTime.Year;
            return Convert.ToDateTime(d.ToString() + "/" + m.ToString() + "/" + y.ToString() + " 00:00:00");
        }

        public static DateTime EndDate(DateTime dateTime)
        {
            int d = dateTime.Day;
            int m = dateTime.Month;
            int y = dateTime.Year;
            return Convert.ToDateTime(d.ToString() + "/" + m.ToString() + "/" + y.ToString() + " 23:59:59.998");
        }

        private static string DocSo3ChuSo(int baso)
        {
            string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
            
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }

        public static string DocTienBangChu(double SoTien, string strTail)
        {
            string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
            int lan, i;
            double so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += " ";
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == " ") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }

        public static string ToFirstUpper(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            string result = "";

            //lấy danh sách các từ  

            string[] words = s.Split(' ');

            foreach (string word in words)
            {
                // từ nào là các khoảng trắng thừa thì bỏ  
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }

            }
            return result.Trim();
        }

        public static int GetWeekOrderInYear(DateTime time)
        {
            CultureInfo myCI = CultureInfo.CurrentCulture;
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            return myCal.GetWeekOfYear(time, myCWR, myFirstDOW);
        }

        public static string NgaySangChu(DateTime ngay)
        {
            string a = " Ngày ... tháng ... năm ... ";
            int d = ngay.Day;
            int m = ngay.Month;
            int y = ngay.Year;
            return a = " Ngày " + d.ToString() + " tháng " + m.ToString() + " năm " + y.ToString();
        }

        public static string NgaySangChu(DateTime ngay, StringDatetimeType type)
        {
            string a = " Ngày ..... tháng ..... năm ..... ";
            int d = 0, m = 0, y = 0, h = 0, p = 0;
            d = ngay.Day;
            m = ngay.Month;
            y = ngay.Year;
            h = ngay.Hour;
            p = ngay.Minute;
            switch (type)
            {
                case StringDatetimeType.Default:
                    return a;
                case StringDatetimeType.FullDate:
                    return " Ngày " + d.ToString() + " tháng " + m.ToString() + " năm " + y.ToString();
                case StringDatetimeType.FullTimeAndDate:
                    return h.ToString() + " giờ " + p.ToString() + ", ngày " + d.ToString() + " tháng " + m.ToString() + " năm " + y.ToString();
                case StringDatetimeType.FullTimeAndDateWithSeperator:
                    return h.ToString() + " giờ " + p.ToString() + ", ngày " + d.ToString() + "/" + m.ToString() + "/" + y.ToString();
                case StringDatetimeType.SpaceTimeAndDate:
                    return " ..... giờ ..... , ngày " + d.ToString() + " tháng " + m.ToString() + " năm " + y.ToString();
                case StringDatetimeType.SpaceTimeAndDateWithSeperator:
                    return " ..... giờ ..... , ngày " + d.ToString() + "/" + m.ToString() + "/" + y.ToString();
                default:
                    return a;
            }
        }

        public static DateTime StringToDatetime(string ngay)
        {
            DateTime dt = System.DateTime.Now;
            if (DateTime.TryParse(ngay, out dt))
            {
                return dt;
            }
            return dt;
        }

        public static bool isNgoaiGioHanhChinh(DateTime dt)
        {
            DateTime dttu1 = new DateTime(dt.Year, dt.Month, dt.Day, Common.GioTu[0], Common.PhutTu[0], 0);
            DateTime dtden1 = new DateTime(dt.Year, dt.Month, dt.Day, Common.GioDen[0], Common.PhutDen[0], 0);
            DateTime dttu2 = new DateTime(dt.Year, dt.Month, dt.Day, Common.GioTu[1], Common.PhutTu[1], 0);
            DateTime dtden2 = new DateTime(dt.Year, dt.Month, dt.Day, Common.GioDen[1], Common.PhutDen[1], 0);
            if (dt >= dttu1 && dt <= dtden1)
                return false;
            if (dt >= dttu2 && dt <= dtden2)
                return false;
            return true;
        }

        public static string StringSplit(string chuoi, char kytu)
        {
            string chuoi_dau = "";
            string[] chuoi_tach = chuoi.Split(new Char[] { kytu });

            foreach (string s in chuoi_tach)
            {

                if (s.Trim() != "")
                    chuoi_dau += s;
            }
            return chuoi_dau;
        }

        public static string ConvertTCVN(string str)
        {
            char[] arrTCVN = {'µ','¸','¶','·','¹','¨', '»', '¾', '¼', '½', 'Æ','©', 'Ç', 'Ê', 'È', 'É', 'Ë',
                                         '®', 'Ì', 'Ð', 'Î', 'Ï', 'Ñ','ª', 'Ò', 'Õ', 'Ó', 'Ô', 'Ö','×', 'Ý', 'Ø', 'Ü', 'Þ',
                                         'ß', 'ã', 'á', 'â', 'ä','«', 'å', 'è', 'æ', 'ç', 'é','¬', 'ê', 'í', 'ë', 'ì', 'î','ï',
                                         'ó', 'ñ', 'ò', 'ô','­', 'õ', 'ø', 'ö', '÷', 'ù','ú', 'ý', 'û', 'ü', 'þ','¡', '¢', '§', '£', '¤', '¥', '¦'
                                        };
            char[] arrUnicode = {'à', 'á', 'ả', 'ã', 'ạ','ă', 'ằ', 'ắ', 'ẳ', 'ẵ', 'ặ','â', 'ầ', 'ấ', 'ẩ', 'ẫ', 'ậ','đ', 'è', 'é', 'ẻ', 'ẽ', 'ẹ',
                                           'ê', 'ề', 'ế', 'ể', 'ễ', 'ệ','ì', 'í', 'ỉ', 'ĩ', 'ị','ò', 'ó', 'ỏ', 'õ', 'ọ','ô', 'ồ', 'ố', 'ổ', 'ỗ', 'ộ',
                                          'ơ', 'ờ', 'ớ', 'ở', 'ỡ', 'ợ','ù', 'ú', 'ủ', 'ũ', 'ụ','ư', 'ừ', 'ứ', 'ử', 'ữ', 'ự','ỳ', 'ý', 'ỷ', 'ỹ', 'ỵ','Ă', 'Â', 'Đ', 'Ê', 'Ô', 'Ơ', 'Ư'
                                        };
            char[] _converter;
            if (string.IsNullOrEmpty(str))
                str = "";
            bool tt = false;
            _converter = new char[str.Length];
            char[] arrStr = str.ToCharArray();
            for (int i = 0; i < arrStr.Length; i++)
            {
                for (int j = 0; j < arrUnicode.Length; j++)
                {
                    if (arrStr[i] == (arrUnicode[j]))
                    {
                        _converter[i] = arrTCVN[j];
                        tt = true;
                        break;
                    }
                }
                if (tt == false)
                {
                    _converter[i] = arrStr[i];
                }
                tt = false;
            }
            return new String(_converter);
        }

        public static string ConvertUnicode(string str)
        {
            char[] arrTCVN = {'µ','¸','¶','·','¹','¨', '»', '¾', '¼', '½', 'Æ','©', 'Ç', 'Ê', 'È', 'É', 'Ë',
                                         '®', 'Ì', 'Ð', 'Î', 'Ï', 'Ñ','ª', 'Ò', 'Õ', 'Ó', 'Ô', 'Ö','×', 'Ý', 'Ø', 'Ü', 'Þ',
                                         'ß', 'ã', 'á', 'â', 'ä','«', 'å', 'è', 'æ', 'ç', 'é','¬', 'ê', 'í', 'ë', 'ì', 'î','ï',
                                         'ó', 'ñ', 'ò', 'ô','­', 'õ', 'ø', 'ö', '÷', 'ù','ú', 'ý', 'û', 'ü', 'þ','¡', '¢', '§', '£', '¤', '¥', '¦'
                                        };
            char[] arrUnicode = {'à', 'á', 'ả', 'ã', 'ạ','ă', 'ằ', 'ắ', 'ẳ', 'ẵ', 'ặ','â', 'ầ', 'ấ', 'ẩ', 'ẫ', 'ậ','đ', 'è', 'é', 'ẻ', 'ẽ', 'ẹ',
                                           'ê', 'ề', 'ế', 'ể', 'ễ', 'ệ','ì', 'í', 'ỉ', 'ĩ', 'ị','ò', 'ó', 'ỏ', 'õ', 'ọ','ô', 'ồ', 'ố', 'ổ', 'ỗ', 'ộ',
                                          'ơ', 'ờ', 'ớ', 'ở', 'ỡ', 'ợ','ù', 'ú', 'ủ', 'ũ', 'ụ','ư', 'ừ', 'ứ', 'ử', 'ữ', 'ự','ỳ', 'ý', 'ỷ', 'ỹ', 'ỵ','Ă', 'Â', 'Đ', 'Ê', 'Ô', 'Ơ', 'Ư'
                                        };
            char[] _converter;
            if (string.IsNullOrEmpty(str))
                str = "";
            bool tt = false;
            _converter = new char[str.Length];
            char[] arrStr = str.ToCharArray();
            for (int i = 0; i < arrStr.Length; i++)
            {
                for (int j = 0; j < arrTCVN.Length; j++)
                {
                    if (arrStr[i] == (arrTCVN[j]))
                    {
                        _converter[i] = arrUnicode[j];
                        tt = true;
                        break;
                    }
                }
                if (tt == false)
                {
                    _converter[i] = arrStr[i];
                }
                tt = false;
            }
            return new String(_converter);
        }

        public static string ConvertFont(string str, string TCVN3Unicode)
        {
            string result = "";
            if (Font == 0)
            {
                if (TCVN3Unicode == "TCVN3")
                    result = ConvertTCVN(str);
                else
                    result = ConvertUnicode(str);
                return result;
            }
            else
                return str;
        }

        public static string ConvertFont(bool convert, string str, string TCVN3Unicode)
        {
            string result = "";
            if (convert)
            {
                if (TCVN3Unicode == "TCVN3")
                    result = ConvertTCVN(str);
                else
                    result = ConvertUnicode(str);
                return result;
            }
            else
                return str;
        }

        public static string FreshString(string chuoi)
        {
            string rs = "";
            if (chuoi != null)
            {
                List<string> list = chuoi.Split(';').Where(p => !string.IsNullOrEmpty(p)).ToList();
                int num = 0;
                foreach (string a in list)
                {

                    num++;
                    if (num != list.Count)
                        rs = rs + a + ";";
                    else
                        rs = rs + a;

                }
            }
            return rs;
        }
    }
}
