using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Micro.Gateways
{

    public class OcelotConfigOptions
    {
        public Reroute[] ReRoutes { get; set; }
    }

    public class Reroute
    {
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public int DownstreamPort { get; set; }
        public string DownstreamHost { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public string[] UpstreamHttpMethod { get; set; }
        public Qosoptions QoSOptions { get; set; }
        public Httphandleroptions HttpHandlerOptions { get; set; }
        public Authenticationoptions AuthenticationOptions { get; set; }
    }

    public class Qosoptions
    {
        public int ExceptionsAllowedBeforeBreaking { get; set; }
        public int DurationOfBreak { get; set; }
        public int TimeoutValue { get; set; }
    }

    public class Httphandleroptions
    {
        public bool AllowAutoRedirect { get; set; }
        public bool UseCookieContainer { get; set; }
    }

    public class Authenticationoptions
    {
        public string AuthenticationProviderKey { get; set; }
        public object[] AllowedScopes { get; set; }
    }

}
