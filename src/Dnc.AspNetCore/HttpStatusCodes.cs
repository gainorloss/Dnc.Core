using System.ComponentModel;

namespace Dnc.AspNetCore
{
    public enum HttpStatusCodes
    {
        [Description("Ok")]
        Ok = 200,
        [Description("Unauthorized")]
        Unauthorized = 401,
        [Description("NotFound")]
        NotFound = 404,
        [Description("BadRequest")]
        BadRequest = 500
    }
}