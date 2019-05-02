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
            #region Test urls
            //https://media.w3.org/2010/05/sintel/trailer.mp4
            //http://www.w3school.com.cn/example/html5/mov_bbb.mp4
            //https://www.w3schools.com/html/movie.mp4
            //http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4
            //https://player.vimeo.com/external/188350983.sd.mp4?s=0bdf01fb5f5c66e43ddae76f573cef2a7786de64&profile_id=164
            //https://player.vimeo.com/external/188355959.sd.mp4?s=e5eea0f749282013db81a7e5cd047c57e066e2b9&profile_id=164
            //https://player.vimeo.com/external/188365455.sd.mp4?s=7343acee6a02371b4ffeb25760bcbf4b627ccadd&profile_id=164
            //https://player.vimeo.com/external/188421287.sd.mp4?s=bdbf8a61c40502211971571fef384f52fe79dbbe&profile_id=164
            #endregion

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
