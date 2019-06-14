using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.WebApi
{
    [DynamicWebApi]
    public interface IAppService : IDynamicWebApi
    { }
}
