using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Web
{
    /// <summary>
    /// Extension methods for <see cref="KnownContentSerializers"/>
    /// </summary>
    public static class KnownContentSerializersExtensions
    {
        public static string ToMimeString(this KnownContentSerializers knownContentSerializer)
        {
            switch (knownContentSerializer)
            {
                case KnownContentSerializers.Json:
                    return "application/json";
                case KnownContentSerializers.Xml:
                    return "application/xml";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
