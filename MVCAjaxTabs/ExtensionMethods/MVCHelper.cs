using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class MVCHelper
    {
        public static string RenderTabCallbackAction(this HtmlHelper helper, string name, string url)
        {
            const string AjaxTabsKey = "AJAXTAB";

            Dictionary<string, string> tabs = null;
            if (HttpContext.Current.Items.Contains(AjaxTabsKey))
            {
                tabs = HttpContext.Current.Items[AjaxTabsKey] as Dictionary<string, string>;
            }
            if (tabs == null)
            {
                tabs = new Dictionary<string, string>();
            }

            tabs.Add(name, url);

            return "<div>loading...</div>";
        }
    }
}