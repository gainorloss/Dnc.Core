using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dnc.API.Models;
using Dnc.SeedWork;

namespace Dnc.API.Services
{
    public class UserAppService
        : IUserAppService
    {
        private readonly IMockRepository _mockRepository;
        public UserAppService(IMockRepository mockRepository)
        {
            _mockRepository = mockRepository;
        }
        public UserInputVm GetUser() => _mockRepository.Create<UserInputVm>();
    }
}
