using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dnc.AspNetCore.WebApi
{
    public class RequestBase
    {
        public RequestBase()
        {
            GuidKey = Guid.NewGuid().ToString();
        }
        public string GuidKey { get; set; }
        public string Sort { get; set; }
        public string Page { get; set; }
        public string ConntentFields { get; set; }

        public PageParameter GetPageParameter()
        {
            var paras = Page.Split(',');

            int? page = null;
            int? size = null;

            if (paras != null && paras.Any())
            {
                if (int.TryParse(paras[0], out var pageNo))
                    page = pageNo;

                if (paras.Length > 1)
                {
                    if (int.TryParse(paras[1], out var sizeNo))
                        size = sizeNo;
                }
            }

            return new PageParameter(page??1,size??5);
        }
    }
}
