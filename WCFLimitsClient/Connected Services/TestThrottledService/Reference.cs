﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFLimitsClient.TestThrottledService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TestThrottledService.IThrottledTestService")]
    public interface IThrottledTestService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IThrottledTestService/TestThrottle", ReplyAction="http://tempuri.org/IThrottledTestService/TestThrottleResponse")]
        string TestThrottle(string taskID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IThrottledTestService/TestThrottle", ReplyAction="http://tempuri.org/IThrottledTestService/TestThrottleResponse")]
        System.Threading.Tasks.Task<string> TestThrottleAsync(string taskID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IThrottledTestServiceChannel : WCFLimitsClient.TestThrottledService.IThrottledTestService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ThrottledTestServiceClient : System.ServiceModel.ClientBase<WCFLimitsClient.TestThrottledService.IThrottledTestService>, WCFLimitsClient.TestThrottledService.IThrottledTestService {
        
        public ThrottledTestServiceClient() {
        }
        
        public ThrottledTestServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ThrottledTestServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ThrottledTestServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ThrottledTestServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string TestThrottle(string taskID) {
            return base.Channel.TestThrottle(taskID);
        }
        
        public System.Threading.Tasks.Task<string> TestThrottleAsync(string taskID) {
            return base.Channel.TestThrottleAsync(taskID);
        }
    }
}
