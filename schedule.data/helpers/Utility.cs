using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.data.helpers
{
    public class Utility
    {
        public string Encode(string encodeMe)
        {
            byte[] encoded = Encoding.UTF8.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }

        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return Encoding.UTF8.GetString(encoded);
        }
        public bool CheckString(string strings)
        {
            if (string.IsNullOrEmpty(strings) || string.IsNullOrEmpty(strings))
            {
                return true;
            }
            else return false;
        }
    }
}
