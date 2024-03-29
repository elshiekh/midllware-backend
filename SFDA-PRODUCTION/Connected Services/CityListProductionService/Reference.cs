﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CityListProductionService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/CityListService")]
    public partial class faultBean
    {
        
        private string fcField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string FC
        {
            get
            {
                return this.fcField;
            }
            set
            {
                this.fcField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/CityListService")]
    public partial class city
    {
        
        private long cITYIDField;
        
        private string cITYNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public long CITYID
        {
            get
            {
                return this.cITYIDField;
            }
            set
            {
                this.cITYIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string CITYNAME
        {
            get
            {
                return this.cITYNAMEField;
            }
            set
            {
                this.cITYNAMEField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/CityListService")]
    public partial class region
    {
        
        private long rEGIONIDField;
        
        private string rEGIONNAMEField;
        
        private city[] cITYLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public long REGIONID
        {
            get
            {
                return this.rEGIONIDField;
            }
            set
            {
                this.rEGIONIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string REGIONNAME
        {
            get
            {
                return this.rEGIONNAMEField;
            }
            set
            {
                this.rEGIONNAMEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("CITY", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public city[] CITYLIST
        {
            get
            {
                return this.cITYLISTField;
            }
            set
            {
                this.cITYLISTField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/CityListService")]
    public partial class cityListServiceResponse
    {
        
        private region[] rEGIONLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("REGION", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public region[] REGIONLIST
        {
            get
            {
                return this.rEGIONLISTField;
            }
            set
            {
                this.rEGIONLISTField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/CityListService")]
    public partial class cityListServiceRequest
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dtts.sfda.gov.sa/CityListService", ConfigurationName="CityListProductionService.CityListService")]
    public interface CityListService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/CityListService/CityListService/getCityListRequest", ReplyAction="http://dtts.sfda.gov.sa/CityListService/CityListService/getCityListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(CityListProductionService.faultBean), Action="http://dtts.sfda.gov.sa/CityListService/CityListService/getCityList/Fault/Service" +
            "Error", Name="ServiceError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        CityListProductionService.getCityListResponse getCityList(CityListProductionService.getCityListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/CityListService/CityListService/getCityListRequest", ReplyAction="http://dtts.sfda.gov.sa/CityListService/CityListService/getCityListResponse")]
        System.Threading.Tasks.Task<CityListProductionService.getCityListResponse> getCityListAsync(CityListProductionService.getCityListRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getCityListRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/CityListService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public CityListProductionService.cityListServiceRequest CityListServiceRequest;
        
        public getCityListRequest()
        {
        }
        
        public getCityListRequest(CityListProductionService.cityListServiceRequest CityListServiceRequest)
        {
            this.CityListServiceRequest = CityListServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getCityListResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/CityListService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public CityListProductionService.cityListServiceResponse CityListServiceResponse;
        
        public getCityListResponse()
        {
        }
        
        public getCityListResponse(CityListProductionService.cityListServiceResponse CityListServiceResponse)
        {
            this.CityListServiceResponse = CityListServiceResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface CityListServiceChannel : CityListProductionService.CityListService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class CityListServiceClient : System.ServiceModel.ClientBase<CityListProductionService.CityListService>, CityListProductionService.CityListService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CityListServiceClient() : 
                base(CityListServiceClient.GetDefaultBinding(), CityListServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.CityListService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CityListServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(CityListServiceClient.GetBindingForEndpoint(endpointConfiguration), CityListServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CityListServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CityListServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CityListServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CityListServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CityListServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public CityListProductionService.getCityListResponse getCityList(CityListProductionService.getCityListRequest request)
        {
            return base.Channel.getCityList(request);
        }
        
        public System.Threading.Tasks.Task<CityListProductionService.getCityListResponse> getCityListAsync(CityListProductionService.getCityListRequest request)
        {
            return base.Channel.getCityListAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CityListService))
            {
                //System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                //result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                System.ServiceModel.BasicHttpsBinding result = new System.ServiceModel.BasicHttpsBinding(System.ServiceModel.BasicHttpsSecurityMode.Transport);
                result.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Basic;
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CityListService))
            {
                return new System.ServiceModel.EndpointAddress("https://rsd.sfda.gov.sa/ws/CityListService/CityListService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return CityListServiceClient.GetBindingForEndpoint(EndpointConfiguration.CityListService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return CityListServiceClient.GetEndpointAddress(EndpointConfiguration.CityListService);
        }
        
        public enum EndpointConfiguration
        {
            
            CityListService,
        }
    }
}
