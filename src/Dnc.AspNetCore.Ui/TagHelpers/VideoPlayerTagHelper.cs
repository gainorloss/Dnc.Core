using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Ui
{
    [HtmlTargetElement("asp-video-player")]
    public class VideoPlayerTagHelper
        : TagHelper
    {
        #region Public props.
        [HtmlAttributeName("asp-hd-url")]
        public string HdUrl { get; set; }
        [HtmlAttributeName("asp-sd-url")]
        public string SdUrl { get; set; }
        #endregion

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("id", "griffith-player");

            #region generate script string.
            var sb = new StringBuilder();
            sb.Append("<script src=\"https://unpkg.com/griffith-standalone/dist/index.umd.min.js\"></script>\r");
            sb.Append("<script>\r");
            sb.Append("var target = document.getElementById('griffith-player');\r");
            sb.Append("var sources = {\r");
            sb.Append("   hd: {\r");
            sb.Append($"     play_url: '{HdUrl}',\r");
            sb.Append("   } ,\r");
            sb.Append("   sd: {\r");
            sb.Append($"     play_url: '{SdUrl}',\r");
            sb.Append("   },\r");
            sb.Append(" };\r");
            sb.Append(" var player = Griffith.createPlayer(target);\r");
            sb.Append(" player.render({sources});\r");
            //sb.Append(" player.dispose();\r");
            sb.Append(" </script>\r"); 
            #endregion

            output.PostElement.SetHtmlContent(sb.ToString());
        }
    }
}
