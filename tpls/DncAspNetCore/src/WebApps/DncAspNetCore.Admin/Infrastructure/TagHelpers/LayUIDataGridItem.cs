using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DncAspNetCore.Admin.Infrastructure.TagHelpers
{
    public class LayUIDataGridItem
    {
        public LayUIDataGridItem(string type, string name, string url = null, string pageUrl = null, string target = "self")
        {
            SetType(type);
            SetName(name);
            SetUrl(url);
            SetPageUrl(pageUrl);
            SetTarget(target);
        }

        private void SetTarget(string target)
        {
            if (!string.IsNullOrWhiteSpace(target))
                Target = "self";

            if (!target.Equals("self") && !target.Equals("blank"))
                throw new ArgumentException($"{nameof(target)}只允许为self、target");

            Target = target;
        }

        private void SetPageUrl(string pageUrl)
        {
            if (!string.IsNullOrWhiteSpace(pageUrl) && !pageUrl.StartsWith('/'))
                throw new ArgumentException($"{nameof(pageUrl)} illegal.");
            PageUrl = pageUrl;
        }

        private void SetUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url) && !url.StartsWith('/'))
                throw new ArgumentException($"{nameof(url)} illegal.");
            Url = url;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} illegal.");
            Name = name;
        }

        private void SetType(string type)
        {
            if (type != null && !type.Equals("r") && !type.Equals("q"))
                throw new ArgumentException($"{nameof(type)} illegal.");
            Type = type;
        }

        public string Type { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
        public string PageUrl { get; private set; }
        public string Target { get; private set; }
    }
}
