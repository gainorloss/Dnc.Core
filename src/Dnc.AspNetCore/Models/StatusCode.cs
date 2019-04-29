using System.ComponentModel;

namespace Dnc.AspNetCore.Models
{
    public enum StatusCode
    {
        [Description("Ok")]
        Ok = 200,
        [Description("Redirect")]
        Redirect = 403,
        [Description("NotFound")]
        NotFound = 404,
        [Description("ServerError")]
        ServerError = 500
    }
}