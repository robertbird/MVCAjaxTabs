using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class MVCHelper
    {
        private static string AjaxTabsKey = "AJAXTAB";

        public static HtmlString AjaxTabsRegistrar(this HtmlHelper helper)
        {
            string javascript = string.Empty;
                
            Dictionary<string, string> tabs = null;
            if (HttpContext.Current.Items.Contains(AjaxTabsKey))
            {
                tabs = HttpContext.Current.Items[AjaxTabsKey] as Dictionary<string, string>;
                if (tabs == null)
                {
                    return new HtmlString(string.Empty);
                }

                foreach (var tabName in tabs.Keys)
                {
                    javascript += "$('body').registerTab('" + tabName + "', '" + tabs[tabName] + "');";
                }

                return new HtmlString("<script type=\"text/javascript\">" + javascript + "</script>");
            }
            return new HtmlString(javascript);
        }

        public static string RenderTabCallbackAction(this HtmlHelper helper, string name, ActionResult actionResult)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext); 

            return helper.RenderTabCallbackAction(name, urlHelper.Action(actionResult));
        }

        public static string RenderTabCallbackAction(this HtmlHelper helper, string name, string url)
        {
            Dictionary<string, string> tabs = null;
            if (HttpContext.Current.Items.Contains(AjaxTabsKey))
            {
                tabs = HttpContext.Current.Items[AjaxTabsKey] as Dictionary<string, string>;

                if (tabs == null)
                {
                    tabs = new Dictionary<string, string>();
                }
                tabs.Add(name, url);

            }
            else
            {
                tabs = new Dictionary<string, string>();
                tabs.Add(name, url);
                HttpContext.Current.Items.Add(AjaxTabsKey, tabs);
            }

            return "<div>loading...</div>";
        }


    }
}