using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dz
{
    public static class Helper
    {
        public static HtmlString CreateFooter(this IHtmlHelper htmlHelper) 
        {
            string result = @$"
            <h4>*Footer* Copyright, {DateTime.Now.Year}, All rights reserved";
            return new HtmlString(result);
        }
    }
}
