using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schedule.com.Models.sessions
{
    public class SessionProvider
    {
        #region Private Properties

        private const string _moduleId = "moduleid";
        private const string _moduleCode = "modulecode";


        #endregion

        #region Public properties

        public string ModuleId
        {
            get
            {
                return this.GetSessionValue(_moduleId).ToString();
            }
            set
            {
                this.SetSessionValue(_moduleId, value);
            }
        }

        public string ModuleCode
        {
            get
            {
                return this.GetSessionValue(_moduleCode).ToString();
            }
            set
            {
                this.SetSessionValue(_moduleCode, value);
            }
        }

        #endregion

        #region Private Method
        private object GetSessionValue(string key)
        {
            if (HttpContext.Current.Session[key]!=null)
            {
                return HttpContext.Current.Session[key];
            }
            else
            {
                throw new NullReferenceException(string.Format("Session with key name \"{0}\" not set value.", key));
            }
        }
        private string GetSessionValue(object key)
        {
            if (HttpContext.Current.Session[key.ToString()] != null)
            {
                return HttpContext.Current.Session[key.ToString()] as string;
            }
            else
            {
                throw new NullReferenceException(string.Format("Session with key name \"{0}\" not set value.", key));
            }
        }
        private T GetSessionValue<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                try
                {
                    return (T)(HttpContext.Current.Session[key]);
                }
                catch (Exception)
                {
                    throw new InvalidCastException(string.Format("Can not cast value to {0}", typeof(T).Name));
                }
                
            }
            else
            {
                throw new NullReferenceException(string.Format("Session with key name \"{0}\" not set value.", key));
            }
        }

        private void SetSessionValue(string key,object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        #endregion
    }
}