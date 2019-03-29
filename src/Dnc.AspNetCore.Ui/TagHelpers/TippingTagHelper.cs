using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Ui
{
    [HtmlTargetElement("asp-tipping")]
    public class TippingTagHelper
        : TagHelper
    {
        #region Public props.
        [HtmlAttributeName("asp-url-alipay")]
        public string AlipayQrImg { get; set; }

        [HtmlAttributeName("asp-url-wechat")]
        public string WechatQrImg { get; set; }
        #endregion

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            #region generate script string.
            var sb = new StringBuilder();
            sb.AppendLine("new tctip({");
            sb.AppendLine("top: '20%',");
            sb.AppendLine("button: {");
            sb.AppendLine(" id: 9,");

            sb.AppendLine("type: 'dashang',");
            sb.AppendLine("},");
            sb.AppendLine("list: [");
            sb.AppendLine(" {");
            sb.AppendLine(" type: 'alipay',");
            sb.AppendLine($"qrImg: '{AlipayQrImg}'");

            sb.AppendLine(" }, {");
            sb.AppendLine("type: 'wechat',");
            sb.AppendLine($"qrImg: '{WechatQrImg}'");
            sb.AppendLine("   }");
            sb.AppendLine(" ]");
            sb.AppendLine("}).init()");
            sb.AppendLine("  </script>");

            var scriptString = sb.ToString(); 
            #endregion

            output.TagName = "script";
            output.Content.SetHtmlContent(scriptString);
            output.PreElement.SetHtmlContent("<script src='http://static.tctip.com/tctip-1.0.0.min.js'></script>");
        }
    }
}
