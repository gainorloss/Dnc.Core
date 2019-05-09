using Dnc.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.API.Services
{
    public interface IUserAppService
    {
        UserInputVm GetUser();
    }
}
