using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.CodeManagement
{
    public class Git
        : IGit
    {
        public Task AddAllAsync(string repositoryUrl)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(string file, string repositoryUrl)
        {
            throw new NotImplementedException();
        }

        public Task CloneAsync(string repositoryUrl)
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync(string repositoryUrl)
        {
            throw new NotImplementedException();
        }

        public Task PullAsync()
        {
            throw new NotImplementedException();
        }

        public Task PushAsync()
        {
            throw new NotImplementedException();
        }
    }
}
