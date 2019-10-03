using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFTestService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TestService : ITestService
    {
        public async Task<string> TestThrottle(string taskID)
        {
            await Task.Delay(1000);
            return await Task.FromResult($"Time: {DateTime.Now:o}, Completed TaskID: {taskID}");
        }

    }

}
