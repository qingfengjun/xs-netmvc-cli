using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc.Html
{
    public static class PagerExtensions
    {
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, int totalItemCount, int pageSize, int pageIndex)
        {
            StringBuilder strBuilder = new StringBuilder();
            var redirectTo = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
            return MvcHtmlString.Create(strBuilder.ToString());
        }
    }
}