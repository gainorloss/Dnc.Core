using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.WebApi
{
    public class LinkViewModel
    {
        public LinkViewModel(string href,string rel,string type)
        {
            Href = href;
            Rel = rel;
            Type = type;
        }
        public string Href { get; set; }
        public string Rel{ get; set; }
        public string Type { get; set; }

    }
}
