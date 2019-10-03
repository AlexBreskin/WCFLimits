using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFThrottledTestService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ThrottledTestService : IThrottledTestService
    {
        public async Task<string> TestThrottle(string taskID)
        {
            await Task.Delay(1000);
            return await Task.FromResult($"Time: {DateTime.Now:o}, Completed TaskID: {taskID}");
        }
    }
}
