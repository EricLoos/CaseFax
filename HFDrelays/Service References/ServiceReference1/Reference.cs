﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HFDrelays.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.GetAlertsSoap")]
    public interface GetAlertsSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        HFDrelays.ServiceReference1.HelloWorldResponse HelloWorld(HFDrelays.ServiceReference1.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<HFDrelays.ServiceReference1.HelloWorldResponse> HelloWorldAsync(HFDrelays.ServiceReference1.HelloWorldRequest request);
        
        // CODEGEN: Generating message contract since element name pass from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCounts", ReplyAction="*")]
        HFDrelays.ServiceReference1.GetCountsResponse GetCounts(HFDrelays.ServiceReference1.GetCountsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCounts", ReplyAction="*")]
        System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetCountsResponse> GetCountsAsync(HFDrelays.ServiceReference1.GetCountsRequest request);
        
        // CODEGEN: Generating message contract since element name pass from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetReplicationHFD", ReplyAction="*")]
        HFDrelays.ServiceReference1.GetReplicationHFDResponse GetReplicationHFD(HFDrelays.ServiceReference1.GetReplicationHFDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetReplicationHFD", ReplyAction="*")]
        System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetReplicationHFDResponse> GetReplicationHFDAsync(HFDrelays.ServiceReference1.GetReplicationHFDRequest request);
        
        // CODEGEN: Generating message contract since element name pass from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetReplicationHFDbits", ReplyAction="*")]
        HFDrelays.ServiceReference1.GetReplicationHFDbitsResponse GetReplicationHFDbits(HFDrelays.ServiceReference1.GetReplicationHFDbitsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetReplicationHFDbits", ReplyAction="*")]
        System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetReplicationHFDbitsResponse> GetReplicationHFDbitsAsync(HFDrelays.ServiceReference1.GetReplicationHFDbitsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public HFDrelays.ServiceReference1.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(HFDrelays.ServiceReference1.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public HFDrelays.ServiceReference1.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(HFDrelays.ServiceReference1.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCountsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetCounts", Namespace="http://tempuri.org/", Order=0)]
        public HFDrelays.ServiceReference1.GetCountsRequestBody Body;
        
        public GetCountsRequest() {
        }
        
        public GetCountsRequest(HFDrelays.ServiceReference1.GetCountsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetCountsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string pass;
        
        public GetCountsRequestBody() {
        }
        
        public GetCountsRequestBody(string pass) {
            this.pass = pass;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCountsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetCountsResponse", Namespace="http://tempuri.org/", Order=0)]
        public HFDrelays.ServiceReference1.GetCountsResponseBody Body;
        
        public GetCountsResponse() {
        }
        
        public GetCountsResponse(HFDrelays.ServiceReference1.GetCountsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetCountsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetCountsResult;
        
        public GetCountsResponseBody() {
        }
        
        public GetCountsResponseBody(string GetCountsResult) {
            this.GetCountsResult = GetCountsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetReplicationHFDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetReplicationHFD", Namespace="http://tempuri.org/", Order=0)]
        public HFDrelays.ServiceReference1.GetReplicationHFDRequestBody Body;
        
        public GetReplicationHFDRequest() {
        }
        
        public GetReplicationHFDRequest(HFDrelays.ServiceReference1.GetReplicationHFDRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetReplicationHFDRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string pass;
        
        public GetReplicationHFDRequestBody() {
        }
        
        public GetReplicationHFDRequestBody(string pass) {
            this.pass = pass;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetReplicationHFDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetReplicationHFDResponse", Namespace="http://tempuri.org/", Order=0)]
        public HFDrelays.ServiceReference1.GetReplicationHFDResponseBody Body;
        
        public GetReplicationHFDResponse() {
        }
        
        public GetReplicationHFDResponse(HFDrelays.ServiceReference1.GetReplicationHFDResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetReplicationHFDResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetReplicationHFDResult;
        
        public GetReplicationHFDResponseBody() {
        }
        
        public GetReplicationHFDResponseBody(string GetReplicationHFDResult) {
            this.GetReplicationHFDResult = GetReplicationHFDResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetReplicationHFDbitsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetReplicationHFDbits", Namespace="http://tempuri.org/", Order=0)]
        public HFDrelays.ServiceReference1.GetReplicationHFDbitsRequestBody Body;
        
        public GetReplicationHFDbitsRequest() {
        }
        
        public GetReplicationHFDbitsRequest(HFDrelays.ServiceReference1.GetReplicationHFDbitsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetReplicationHFDbitsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string pass;
        
        public GetReplicationHFDbitsRequestBody() {
        }
        
        public GetReplicationHFDbitsRequestBody(string pass) {
            this.pass = pass;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetReplicationHFDbitsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetReplicationHFDbitsResponse", Namespace="http://tempuri.org/", Order=0)]
        public HFDrelays.ServiceReference1.GetReplicationHFDbitsResponseBody Body;
        
        public GetReplicationHFDbitsResponse() {
        }
        
        public GetReplicationHFDbitsResponse(HFDrelays.ServiceReference1.GetReplicationHFDbitsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetReplicationHFDbitsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int GetReplicationHFDbitsResult;
        
        public GetReplicationHFDbitsResponseBody() {
        }
        
        public GetReplicationHFDbitsResponseBody(int GetReplicationHFDbitsResult) {
            this.GetReplicationHFDbitsResult = GetReplicationHFDbitsResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GetAlertsSoapChannel : HFDrelays.ServiceReference1.GetAlertsSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetAlertsSoapClient : System.ServiceModel.ClientBase<HFDrelays.ServiceReference1.GetAlertsSoap>, HFDrelays.ServiceReference1.GetAlertsSoap {
        
        public GetAlertsSoapClient() {
        }
        
        public GetAlertsSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetAlertsSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetAlertsSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetAlertsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HFDrelays.ServiceReference1.HelloWorldResponse HFDrelays.ServiceReference1.GetAlertsSoap.HelloWorld(HFDrelays.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            HFDrelays.ServiceReference1.HelloWorldRequest inValue = new HFDrelays.ServiceReference1.HelloWorldRequest();
            inValue.Body = new HFDrelays.ServiceReference1.HelloWorldRequestBody();
            HFDrelays.ServiceReference1.HelloWorldResponse retVal = ((HFDrelays.ServiceReference1.GetAlertsSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HFDrelays.ServiceReference1.HelloWorldResponse> HFDrelays.ServiceReference1.GetAlertsSoap.HelloWorldAsync(HFDrelays.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<HFDrelays.ServiceReference1.HelloWorldResponse> HelloWorldAsync() {
            HFDrelays.ServiceReference1.HelloWorldRequest inValue = new HFDrelays.ServiceReference1.HelloWorldRequest();
            inValue.Body = new HFDrelays.ServiceReference1.HelloWorldRequestBody();
            return ((HFDrelays.ServiceReference1.GetAlertsSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HFDrelays.ServiceReference1.GetCountsResponse HFDrelays.ServiceReference1.GetAlertsSoap.GetCounts(HFDrelays.ServiceReference1.GetCountsRequest request) {
            return base.Channel.GetCounts(request);
        }
        
        public string GetCounts(string pass) {
            HFDrelays.ServiceReference1.GetCountsRequest inValue = new HFDrelays.ServiceReference1.GetCountsRequest();
            inValue.Body = new HFDrelays.ServiceReference1.GetCountsRequestBody();
            inValue.Body.pass = pass;
            HFDrelays.ServiceReference1.GetCountsResponse retVal = ((HFDrelays.ServiceReference1.GetAlertsSoap)(this)).GetCounts(inValue);
            return retVal.Body.GetCountsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetCountsResponse> HFDrelays.ServiceReference1.GetAlertsSoap.GetCountsAsync(HFDrelays.ServiceReference1.GetCountsRequest request) {
            return base.Channel.GetCountsAsync(request);
        }
        
        public System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetCountsResponse> GetCountsAsync(string pass) {
            HFDrelays.ServiceReference1.GetCountsRequest inValue = new HFDrelays.ServiceReference1.GetCountsRequest();
            inValue.Body = new HFDrelays.ServiceReference1.GetCountsRequestBody();
            inValue.Body.pass = pass;
            return ((HFDrelays.ServiceReference1.GetAlertsSoap)(this)).GetCountsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HFDrelays.ServiceReference1.GetReplicationHFDResponse HFDrelays.ServiceReference1.GetAlertsSoap.GetReplicationHFD(HFDrelays.ServiceReference1.GetReplicationHFDRequest request) {
            return base.Channel.GetReplicationHFD(request);
        }
        
        public string GetReplicationHFD(string pass) {
            HFDrelays.ServiceReference1.GetReplicationHFDRequest inValue = new HFDrelays.ServiceReference1.GetReplicationHFDRequest();
            inValue.Body = new HFDrelays.ServiceReference1.GetReplicationHFDRequestBody();
            inValue.Body.pass = pass;
            HFDrelays.ServiceReference1.GetReplicationHFDResponse retVal = ((HFDrelays.ServiceReference1.GetAlertsSoap)(this)).GetReplicationHFD(inValue);
            return retVal.Body.GetReplicationHFDResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetReplicationHFDResponse> HFDrelays.ServiceReference1.GetAlertsSoap.GetReplicationHFDAsync(HFDrelays.ServiceReference1.GetReplicationHFDRequest request) {
            return base.Channel.GetReplicationHFDAsync(request);
        }
        
        public System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetReplicationHFDResponse> GetReplicationHFDAsync(string pass) {
            HFDrelays.ServiceReference1.GetReplicationHFDRequest inValue = new HFDrelays.ServiceReference1.GetReplicationHFDRequest();
            inValue.Body = new HFDrelays.ServiceReference1.GetReplicationHFDRequestBody();
            inValue.Body.pass = pass;
            return ((HFDrelays.ServiceReference1.GetAlertsSoap)(this)).GetReplicationHFDAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HFDrelays.ServiceReference1.GetReplicationHFDbitsResponse HFDrelays.ServiceReference1.GetAlertsSoap.GetReplicationHFDbits(HFDrelays.ServiceReference1.GetReplicationHFDbitsRequest request) {
            return base.Channel.GetReplicationHFDbits(request);
        }
        
        public int GetReplicationHFDbits(string pass) {
            HFDrelays.ServiceReference1.GetReplicationHFDbitsRequest inValue = new HFDrelays.ServiceReference1.GetReplicationHFDbitsRequest();
            inValue.Body = new HFDrelays.ServiceReference1.GetReplicationHFDbitsRequestBody();
            inValue.Body.pass = pass;
            HFDrelays.ServiceReference1.GetReplicationHFDbitsResponse retVal = ((HFDrelays.ServiceReference1.GetAlertsSoap)(this)).GetReplicationHFDbits(inValue);
            return retVal.Body.GetReplicationHFDbitsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetReplicationHFDbitsResponse> HFDrelays.ServiceReference1.GetAlertsSoap.GetReplicationHFDbitsAsync(HFDrelays.ServiceReference1.GetReplicationHFDbitsRequest request) {
            return base.Channel.GetReplicationHFDbitsAsync(request);
        }
        
        public System.Threading.Tasks.Task<HFDrelays.ServiceReference1.GetReplicationHFDbitsResponse> GetReplicationHFDbitsAsync(string pass) {
            HFDrelays.ServiceReference1.GetReplicationHFDbitsRequest inValue = new HFDrelays.ServiceReference1.GetReplicationHFDbitsRequest();
            inValue.Body = new HFDrelays.ServiceReference1.GetReplicationHFDbitsRequestBody();
            inValue.Body.pass = pass;
            return ((HFDrelays.ServiceReference1.GetAlertsSoap)(this)).GetReplicationHFDbitsAsync(inValue);
        }
    }
}