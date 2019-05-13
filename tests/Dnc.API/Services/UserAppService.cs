using Dnc.API.Models;
using Dnc.Seedwork;

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
