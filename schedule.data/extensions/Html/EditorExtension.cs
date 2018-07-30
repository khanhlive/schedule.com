using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Properties;
using System.Web.Routing;
using schedule.data.extensions.Html;
using schedule.data.helpers.Library;

namespace System
{
    public static class EditorExtension
    {
        #region Checkbox Custom
        public static MvcHtmlString ThemeCheckBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.ThemeCheckBox(name, null);
        }
        public static MvcHtmlString ThemeCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked)
        {
            return htmlHelper.ThemeCheckBox(name, isChecked, null);
        }
        public static MvcHtmlString ThemeCheckBox(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return htmlHelper.ThemeCheckBox(name, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
        }
        public static MvcHtmlString ThemeCheckBox(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            return ThemeCheckBoxHelper(htmlHelper, null, name, null, htmlAttributes);
        }
        public static MvcHtmlString ThemeCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked, object htmlAttributes)
        {
            return htmlHelper.ThemeCheckBox(name, isChecked, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
        }
        public static MvcHtmlString ThemeCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            return ThemeCheckBoxHelper(htmlHelper, null, name, new bool?(isChecked), htmlAttributes);
        }
        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            return htmlHelper.ThemeCheckBoxFor<TModel>(expression, ((IDictionary<string, object>)null));
        }
        public static MvcHtmlString ThemeCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            bool flag;
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, bool>(expression, htmlHelper.ViewData);
            bool? isChecked = null;
            if ((metadata.Model != null) && bool.TryParse(metadata.Model.ToString(), out flag))
            {
                isChecked = new bool?(flag);
            }
            return ThemeCheckBoxHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), isChecked, htmlAttributes);
        }
        public static MvcHtmlString ThemeCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            return htmlHelper.ThemeCheckBoxFor<TModel>(expression, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
        }
        private static MvcHtmlString ThemeCheckBoxHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, bool? isChecked, IDictionary<string, object> htmlAttributes)
        {
            RouteValueDictionary dictionary = ToRouteValueDictionary(htmlAttributes);
            bool hasValue = isChecked.HasValue;
            if (hasValue)
            {
                dictionary.Remove("checked");
            }
            bool? nullable = isChecked;
            return InputHelper(htmlHelper, InputType.CheckBox, metadata, name, "true", !hasValue, nullable.HasValue ? nullable.GetValueOrDefault() : false, true, false, null, dictionary);
        }
        private static RouteValueDictionary ToRouteValueDictionary(IDictionary<string, object> dictionary)
        {
            if (dictionary != null)
            {
                return new RouteValueDictionary(dictionary);
            }
            return new RouteValueDictionary();
        }
        private static MvcHtmlString InputHelper(HtmlHelper htmlHelper, InputType inputType, ModelMetadata metadata, string name, object value, bool useViewData, bool isChecked, bool setId, bool isExplicitValue, string format, IDictionary<string, object> htmlAttributes)
        {
            ModelState state;
            string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullHtmlFieldName))
            {
                throw new ArgumentException("", "name");
            }
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes<string, object>(htmlAttributes);
            tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(inputType));
            if (inputType != InputType.CheckBox)
            {
                tagBuilder.MergeAttribute("name", fullHtmlFieldName, true);
            }
            else
            {
                tagBuilder.MergeAttribute("onchange", "oncheckboxchange(this);");
            }
            string str2 = htmlHelper.FormatValue(value, format);
            bool flag = false;
            HtmlHelperCustom htmlHelperCustom = new HtmlHelperCustom(htmlHelper);
            switch (inputType)
            {
                case InputType.CheckBox:
                    {
                        bool? modelStateValue = htmlHelperCustom.GetModelStateValue(fullHtmlFieldName, typeof(bool)) as bool?;
                        if (modelStateValue.HasValue)
                        {
                            isChecked = modelStateValue.Value;
                            flag = true;
                        }
                        break;
                    }
                case InputType.Password:
                    if (value != null)
                    {
                        tagBuilder.MergeAttribute("value", str2, isExplicitValue);
                    }
                    goto Label_016A;

                case InputType.Radio:
                    break;

                default:
                    {
                        string str3 = (string)htmlHelperCustom.GetModelStateValue(fullHtmlFieldName, typeof(string));
                        tagBuilder.MergeAttribute("value", str3 ?? (useViewData ? htmlHelperCustom.EvalString(fullHtmlFieldName, format) : str2), isExplicitValue);
                        goto Label_016A;
                    }
            }
            if (!flag)
            {
                string a = htmlHelperCustom.GetModelStateValue(fullHtmlFieldName, typeof(string)) as string;
                if (a != null)
                {
                    isChecked = string.Equals(a, str2, StringComparison.Ordinal);
                    flag = true;
                }
            }
            if (!flag & useViewData)
            {
                isChecked = htmlHelperCustom.EvalBoolean(fullHtmlFieldName);
            }
            if (isChecked)
            {
                tagBuilder.MergeAttribute("checked", "checked");
            }
            tagBuilder.MergeAttribute("value", str2, isExplicitValue);
            Label_016A:
            if (setId)
            {
                tagBuilder.GenerateId(fullHtmlFieldName);
            }
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out state) && (state.Errors.Count > 0))
            {
                tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }
            tagBuilder.MergeAttributes<string, object>(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));
            if (inputType == InputType.CheckBox)
            {
                StringBuilder builder1 = new StringBuilder();
                TagBuilder builder2 = new TagBuilder("input");
                builder2.MergeAttribute("type", HtmlHelper.GetInputTypeString(InputType.Hidden));
                builder2.MergeAttribute("name", fullHtmlFieldName);
                builder2.MergeAttribute("value", isChecked ? "true" : "false");
                builder1.Append(builder2.ToString(TagRenderMode.SelfClosing));
                builder1.Append(tagBuilder.ToString(TagRenderMode.SelfClosing));
                //TagBuilder labelTag = new TagBuilder("label");
                //string forId = string.Format("ckb{0}", fullHtmlFieldName);
                //if (htmlAttributes.ContainsKey("id"))
                //{
                //    object _id = "";
                //    if (htmlAttributes.TryGetValue("id", out _id)){
                //        forId = _id.ToString();
                //    }
                //}
                //labelTag.MergeAttribute("for", forId);
                //labelTag.SetInnerText
                //builder1.Append(labelTag.ToString(TagRenderMode.Normal));
                return MvcHtmlString.Create(builder1.ToString());
            }
            return tagBuilder.ToMvcHtmlString(TagRenderMode.SelfClosing);
        }
        #endregion

        #region EncodeActionLink

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            return htmlHelper.ThemeActionLink(linkText, actionName, null, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues)
        {
            return htmlHelper.ThemeActionLink(linkText, actionName, null, TypeHelper.ObjectToDictionary(routeValues), new RouteValueDictionary());
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            return htmlHelper.ThemeActionLink(linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues)
        {
            return htmlHelper.ThemeActionLink(linkText, actionName, null, routeValues, new RouteValueDictionary());
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, object htmlAttributes)
        {
            return htmlHelper.ThemeActionLink(linkText, actionName, null, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.ThemeActionLink(linkText, actionName, null, routeValues, htmlAttributes);
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            return htmlHelper.ThemeActionLink(linkText, actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            if (string.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("", "linkText");
            }
            return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null, actionName, controllerName, routeValues, htmlAttributes));
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        {
            return htmlHelper.ThemeActionLink(linkText, actionName, controllerName, protocol, hostName, fragment, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ThemeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            if (string.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("", "linkText");
            }
            return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes));
        }

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, object routeValues)
        //{
        //    return htmlHelper.RouteLink(linkText, TypeHelper.ObjectToDictionary(routeValues));
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName)
        //{
        //    return htmlHelper.RouteLink(linkText, routeName, null);
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, RouteValueDictionary routeValues)
        //{
        //    return htmlHelper.RouteLink(linkText, routeValues, new RouteValueDictionary());
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, object routeValues, object htmlAttributes)
        //{
        //    return htmlHelper.RouteLink(linkText, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, object routeValues)
        //{
        //    return htmlHelper.RouteLink(linkText, routeName, TypeHelper.ObjectToDictionary(routeValues));
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues)
        //{
        //    return htmlHelper.RouteLink(linkText, routeName, routeValues, new RouteValueDictionary());
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        //{
        //    return htmlHelper.RouteLink(linkText, null, routeValues, htmlAttributes);
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, object routeValues, object htmlAttributes)
        //{
        //    return htmlHelper.RouteLink(linkText, routeName, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        //{
        //    if (string.IsNullOrEmpty(linkText))
        //    {
        //        throw new ArgumentException("", "linkText");
        //    }
        //    return MvcHtmlString.Create(HtmlHelper.GenerateRouteLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, routeName, routeValues, htmlAttributes));
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        //{
        //    return htmlHelper.RouteLink(linkText, routeName, protocol, hostName, fragment, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        //}

        //public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        //{
        //    if (string.IsNullOrEmpty(linkText))
        //    {
        //        throw new ArgumentException("", "linkText");
        //    }
        //    return MvcHtmlString.Create(HtmlHelper.GenerateRouteLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, routeName, protocol, hostName, fragment, routeValues, htmlAttributes));
        //}

        #endregion
    }
    internal static class TypeHelper
    {
        public static void AddAnonymousObjectToDictionary(IDictionary<string, object> dictionary, object value)
        {
            foreach (KeyValuePair<string, object> pair in ObjectToDictionary(value))
            {
                dictionary.Add(pair);
            }
        }

        public static bool IsAnonymousType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (((!Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false) || !type.IsGenericType) || !type.Name.Contains("AnonymousType")) || (!type.Name.StartsWith("<>", StringComparison.OrdinalIgnoreCase) && !type.Name.StartsWith("VB$", StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            return ((type.Attributes & TypeAttributes.AnsiClass) == TypeAttributes.AnsiClass);
        }

        public static RouteValueDictionary ObjectToDictionary(object value)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary();
            if (value != null)
            {
                foreach (PropertyHelper helper in PropertyHelper.GetProperties(value))
                {
                    dictionary.Add(helper.Name, helper.GetValue(value));
                }
            }
            return dictionary;
        }

        public static RouteValueDictionary ObjectToDictionaryUncached(object value)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary();
            if (value != null)
            {
                foreach (PropertyHelper helper in PropertyHelper.GetProperties(value))
                {
                    dictionary.Add(helper.Name, helper.GetValue(value));
                }
            }
            return dictionary;
        }
    }

}
