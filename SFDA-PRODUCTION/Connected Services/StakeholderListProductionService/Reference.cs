﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StakeholderListProductionService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/StakeholderListService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/StakeholderListService")]
    public partial class stakeholder
    {
        
        private string gLNField;
        
        private string sTAKEHOLDERNAMEField;
        
        private string cITYNAMEField;
        
        private string aDDRESSField;
        
        private bool iSACTIVEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string GLN
        {
            get
            {
                return this.gLNField;
            }
            set
            {
                this.gLNField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string STAKEHOLDERNAME
        {
            get
            {
                return this.sTAKEHOLDERNAMEField;
            }
            set
            {
                this.sTAKEHOLDERNAMEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string ADDRESS
        {
            get
            {
                return this.aDDRESSField;
            }
            set
            {
                this.aDDRESSField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public bool ISACTIVE
        {
            get
            {
                return this.iSACTIVEField;
            }
            set
            {
                this.iSACTIVEField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/StakeholderListService")]
    public partial class stakeholderListServiceResponse
    {
        
        private stakeholder[] sTAKEHOLDERLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("STAKEHOLDER", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public stakeholder[] STAKEHOLDERLIST
        {
            get
            {
                return this.sTAKEHOLDERLISTField;
            }
            set
            {
                this.sTAKEHOLDERLISTField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/StakeholderListService")]
    public partial class stakeholderListServiceRequest
    {
        
        private string sTAKEHOLDERTYPEField;
        
        private bool gETALLField;
        
        private string cITYIDField;
        
        public stakeholderListServiceRequest()
        {
            this.gETALLField = false;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string STAKEHOLDERTYPE
        {
            get
            {
                return this.sTAKEHOLDERTYPEField;
            }
            set
            {
                this.sTAKEHOLDERTYPEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public bool GETALL
        {
            get
            {
                return this.gETALLField;
            }
            set
            {
                this.gETALLField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string CITYID
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
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dtts.sfda.gov.sa/StakeholderListService", ConfigurationName="StakeholderListProductionService.StakeholderListService")]
    public interface StakeholderListService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/StakeholderListService/StakeholderListService/getStakehol" +
            "derListRequest", ReplyAction="http://dtts.sfda.gov.sa/StakeholderListService/StakeholderListService/getStakehol" +
            "derListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(StakeholderListProductionService.faultBean), Action="http://dtts.sfda.gov.sa/StakeholderListService/StakeholderListService/getStakehol" +
            "derList/Fault/ServiceError", Name="ServiceError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        StakeholderListProductionService.getStakeholderListResponse getStakeholderList(StakeholderListProductionService.getStakeholderListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/StakeholderListService/StakeholderListService/getStakehol" +
            "derListRequest", ReplyAction="http://dtts.sfda.gov.sa/StakeholderListService/StakeholderListService/getStakehol" +
            "derListResponse")]
        System.Threading.Tasks.Task<StakeholderListProductionService.getStakeholderListResponse> getStakeholderListAsync(StakeholderListProductionService.getStakeholderListRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getStakeholderListRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/StakeholderListService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public StakeholderListProductionService.stakeholderListServiceRequest StakeholderListServiceRequest;
        
        public getStakeholderListRequest()
        {
        }
        
        public getStakeholderListRequest(StakeholderListProductionService.stakeholderListServiceRequest StakeholderListServiceRequest)
        {
            this.StakeholderListServiceRequest = StakeholderListServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getStakeholderListResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/StakeholderListService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public StakeholderListProductionService.stakeholderListServiceResponse StakeholderListServiceResponse;
        
        public getStakeholderListResponse()
        {
        }
        
        public getStakeholderListResponse(StakeholderListProductionService.stakeholderListServiceResponse StakeholderListServiceResponse)
        {
            this.StakeholderListServiceResponse = StakeholderListServiceResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface StakeholderListServiceChannel : StakeholderListProductionService.StakeholderListService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class StakeholderListServiceClient : System.ServiceModel.ClientBase<StakeholderListProductionService.StakeholderListService>, StakeholderListProductionService.StakeholderListService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public StakeholderListServiceClient() : 
                base(StakeholderListServiceClient.GetDefaultBinding(), StakeholderListServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.StakeholderListService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StakeholderListServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(StakeholderListServiceClient.GetBindingForEndpoint(endpointConfiguration), StakeholderListServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StakeholderListServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(StakeholderListServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StakeholderListServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(StakeholderListServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StakeholderListServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public StakeholderListProductionService.getStakeholderListResponse getStakeholderList(StakeholderListProductionService.getStakeholderListRequest request)
        {
            return base.Channel.getStakeholderList(request);
        }
        
        public System.Threading.Tasks.Task<StakeholderListProductionService.getStakeholderListResponse> getStakeholderListAsync(StakeholderListProductionService.getStakeholderListRequest request)
        {
            return base.Channel.getStakeholderListAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.StakeholderListService))
            {
                //System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                System.ServiceModel.BasicHttpsBinding result = new System.ServiceModel.BasicHttpsBinding(System.ServiceModel.BasicHttpsSecurityMode.Transport);
                result.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Basic;
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
               // result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.StakeholderListService))
            {
                return new System.ServiceModel.EndpointAddress("https://rsd.sfda.gov.sa/ws/StakeholderListService/StakeholderListService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return StakeholderListServiceClient.GetBindingForEndpoint(EndpointConfiguration.StakeholderListService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return StakeholderListServiceClient.GetEndpointAddress(EndpointConfiguration.StakeholderListService);
        }
        
        public enum EndpointConfiguration
        {
            
            StakeholderListService,
        }
    }
}