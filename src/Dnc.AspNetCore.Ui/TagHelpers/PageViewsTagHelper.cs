using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Ui
{
    [HtmlTargetElement("asp-page-views")]
    public class PageViewsTagHelper
        : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            #region generate script string.
            var sb = new StringBuilder();

            sb.AppendLine("var _hmt = _hmt || [];");
            sb.AppendLine("(function() {");
            sb.AppendLine("var hm = document.createElement('script');");
            sb.AppendLine("hm.src = 'https://hm.baidu.com/hm.js?cec5e45542bccd144ca87f3279381e23';");
            sb.AppendLine("var s = document.getElementsByTagName('script')[0]");
            sb.AppendLine("s.parentNode.insertBefore(hm, s)");
            sb.AppendLine("})();");

            var scriptString = sb.ToString();
            #endregion

            output.TagName = "script";
            output.Content.SetHtmlContent(scriptString);
        }
    }
}
