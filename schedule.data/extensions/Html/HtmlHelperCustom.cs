using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace schedule.data.extensions.Html
{
    public class HtmlHelperCustom
    {
        protected System.Web.Mvc.HtmlHelper htmlHelper;
        public HtmlHelperCustom(System.Web.Mvc.HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }
        public object GetModelStateValue(string key, Type destinationType)
        {
            System.Web.Mvc.ModelState state;
            if (this.htmlHelper.ViewData.ModelState.TryGetValue(key, out state) && (state.Value != null))
            {
                return state.Value.ConvertTo(destinationType, null);
            }
            return null;
        }
        public bool EvalBoolean(string key)
        {
            return Convert.ToBoolean(this.htmlHelper.ViewData.Eval(key), CultureInfo.InvariantCulture);
        }

        public string EvalString(string key)
        {
            return Convert.ToString(this.htmlHelper.ViewData.Eval(key), CultureInfo.CurrentCulture);
        }

        public string EvalString(string key, string format)
        {
            return Convert.ToString(this.htmlHelper.ViewData.Eval(key, format), CultureInfo.CurrentCulture);
        }
    }
    public sealed class DynamicViewDataDictionary : DynamicObject
    {
        private readonly Func<ViewDataDictionary> _viewDataThunk;

        public DynamicViewDataDictionary(Func<ViewDataDictionary> viewDataThunk)
        {
            this._viewDataThunk = viewDataThunk;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this.ViewData.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this.ViewData[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.ViewData[binder.Name] = value;
            return true;
        }

        private ViewDataDictionary ViewData
        {
            get
            {
                return this._viewDataThunk();
            }
        }
    }
    
    public static class TagBuilderCustomExtension
    {
        public static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
}
