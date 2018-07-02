using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace schedule.data.helpers
{
    public static class DataConverter
    {

        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public static int StringToInt(string value)
        {
            int obj = 0;
            if (int.TryParse(value, out obj))
            {
                return obj;
            }
            else throw new ArgumentNullException("Chuỗi không phải là một số");
        }
        public static int StringToInt(object value)
        {
            int obj = 0;
            if (value!=null)
            {

                if (int.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }
                else throw new ArgumentNullException("Chuỗi không phải là một số");
            }
            else
                throw new ArgumentNullException("Chuỗi không phải là một số");;
        }

        public static int? ToInt(string value)
        {
            int obj = 0;
            if (int.TryParse(value, out obj))
            {
                return obj;
            }
            else return null;
        }
        public static int? ToInt(object value)
        {
            int obj = 0;
            if (value != null)
            {
                if (int.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }
                else return null;
            }
            else return null;
        }

        public static byte? ToByte(string value)
        {
            byte obj = 0;
            if (byte.TryParse(value, out obj))
            {
                return obj;
            }
            else return null;
        }

        public static string ToUpper(string value)
        {
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
            {
                return value.ToUpper();
            }
            else return string.Empty;
        }

        public static string ImageToBase64(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(filePath))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, image.RawFormat);
                        byte[] imagesBytes = memoryStream.ToArray();
                        string base64 = Convert.ToBase64String(imagesBytes);
                        return base64;
                    }
                }
            }
            else return string.Empty;
        }

        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public static byte[] GetBytesFromImagePath(string path)
        {
            if (File.Exists(path))
            {
                using (Image image = Image.FromFile(path))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, image.RawFormat);
                        byte[] imagesBytes = memoryStream.ToArray();
                        return imagesBytes;
                    }
                }
            }
            else return null;
        }
        public static byte[] GetBytesFromImage(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(image);
                bmp.Save(memoryStream, image.RawFormat);
                byte[] imagesBytes = memoryStream.ToArray();
                return imagesBytes;
            }
        }
        public static Image GetImageFromBytes(byte[] bytes)
        {
            try
            {
                using (var ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    return image;
                }
            }
            catch { return null; }
        }

        public static double ConvertToDouble(string value)
        {
            double obj = 0;
            if (double.TryParse(value, out obj)) return obj;
            else
                throw new ArgumentNullException("Chuỗi không đúng định dạng");
        }
        public static double? ConvertToDoubleNullable(string value)
        {
            double obj = 0;
            if (double.TryParse(value, out obj)) return obj;
            else
                return null;
        }
        public static double ConvertToDouble(object value)
        {
            double obj = 0;
            if (value != null)
            {

                if (value.GetType() == obj.GetType())
                {
                    return (double)value;
                }
                else
                if (double.TryParse((string)value, out obj)) return obj;
                else
                    throw new ArgumentNullException("Chuỗi không đúng định dạng");

            }
            else throw new ArgumentNullException("Chuỗi không đúng định dạng");
        }
        public static double? ConvertToDoubleNullable(object value)
        {
            double obj = 0;
            if (value != null)
            {

                if (value.GetType() == obj.GetType())
                {
                    return (double)value;
                }
                else
                if (double.TryParse((string)value, out obj)) return obj;
                else
                    return null;
            }
            else return null;
        }
    }
}
