using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFTestService
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        Task<string> TestThrottle(string taskID);
    }
}
