using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.CodeManagement
{
    /// <summary>
    /// Constraint for git operations.
    /// </summary>
    public interface IGit
    {
        Task CloneAsync(string repositoryUrl);

        Task AddAllAsync(string repositoryUrl);

        Task AddAsync(string file,string repositoryUrl);

        Task CommitAsync(string repositoryUrl);

        Task PullAsync();
        Task PushAsync();
    }
}
