using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace System
{
    public static class HtmlQueryStringBuilder
    {
        public static object GetValueQueryString(this WebViewPage viewPage, object value)
        {
            if (value!=null)
            {
                return value;
            }else
                return null;
        }
    }
}
