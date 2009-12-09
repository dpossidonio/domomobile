﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestProxy.ServiceProxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://DomoMobile.com", ConfigurationName="ServiceProxy.IDomoService")]
    public interface IDomoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://DomoMobile.com/IDomoService/Echo", ReplyAction="http://DomoMobile.com/IDomoService/EchoResponse")]
        string Echo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://DomoMobile.com/IDomoService/Login", ReplyAction="http://DomoMobile.com/IDomoService/LoginResponse")]
        bool Login(string Username, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://DomoMobile.com/IDomoService/GetHouses", ReplyAction="http://DomoMobile.com/IDomoService/GetHousesResponse")]
        string[] GetHouses(string Token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://DomoMobile.com/IDomoService/GetHouseDescription", ReplyAction="http://DomoMobile.com/IDomoService/GetHouseDescriptionResponse")]
        string GetHouseDescription(string Token, int HouseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://DomoMobile.com/IDomoService/Set", ReplyAction="http://DomoMobile.com/IDomoService/SetResponse")]
        int Set(string Token, int HouseId, int RefDevice, int RefProperty, string Value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://DomoMobile.com/IDomoService/Get", ReplyAction="http://DomoMobile.com/IDomoService/GetResponse")]
        string Get(string Token, int HouseId, int RefDevice, int RefProperty);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IDomoServiceChannel : TestProxy.ServiceProxy.IDomoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class DomoServiceClient : System.ServiceModel.ClientBase<TestProxy.ServiceProxy.IDomoService>, TestProxy.ServiceProxy.IDomoService {
        
        public DomoServiceClient() {
        }
        
        public DomoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DomoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DomoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DomoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Echo() {
            return base.Channel.Echo();
        }
        
        public bool Login(string Username, string Password) {
            return base.Channel.Login(Username, Password);
        }
        
        public string[] GetHouses(string Token) {
            return base.Channel.GetHouses(Token);
        }
        
        public string GetHouseDescription(string Token, int HouseId) {
            return base.Channel.GetHouseDescription(Token, HouseId);
        }
        
        public int Set(string Token, int HouseId, int RefDevice, int RefProperty, string Value) {
            return base.Channel.Set(Token, HouseId, RefDevice, RefProperty, Value);
        }
        
        public string Get(string Token, int HouseId, int RefDevice, int RefProperty) {
            return base.Channel.Get(Token, HouseId, RefDevice, RefProperty);
        }
    }
}
