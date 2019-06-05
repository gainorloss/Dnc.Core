using System.Threading;

namespace Dnc.UnitTests.Queries
{
    public class LogQueries
         : ILogQueries
    {
        public string GetAllLogs()
        {
            Thread.Sleep(3000);
            throw new System.Exception();
        }
    }
}
