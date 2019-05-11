using System.ComponentModel;

namespace Dnc.AspNetCore.Controllers
{
    public enum HttpStatusCodes
    {
        [Description("Ok")]
        Ok = 200,
        [Description("Unauthorized")]
        Unauthorized = 403,
        [Description("NotFound")]
        NotFound = 404,
        [Description("BadRequest")]
        BadRequest = 500
    }
}