using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFThrottledTestService
{
    [ServiceContract]
    public interface IThrottledTestService
    {
        [OperationContract]
        Task<string> TestThrottle(string taskID);
    }


}
