﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumeProductService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ConsumeService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ConsumeService")]
    public partial class productResponse
    {
        
        private string gTINField;
        
        private string snField;
        
        private string bnField;
        
        private System.DateTime xdField;
        
        private bool xdFieldSpecified;
        
        private string rcField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string GTIN
        {
            get
            {
                return this.gTINField;
            }
            set
            {
                this.gTINField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string SN
        {
            get
            {
                return this.snField;
            }
            set
            {
                this.snField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string BN
        {
            get
            {
                return this.bnField;
            }
            set
            {
                this.bnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=3)]
        public System.DateTime XD
        {
            get
            {
                return this.xdField;
            }
            set
            {
                this.xdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool XDSpecified
        {
            get
            {
                return this.xdFieldSpecified;
            }
            set
            {
                this.xdFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string RC
        {
            get
            {
                return this.rcField;
            }
            set
            {
                this.rcField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ConsumeService")]
    public partial class consumeServiceResponse
    {
        
        private string nOTIFICATIONIDField;
        
        private productResponse[] pRODUCTLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string NOTIFICATIONID
        {
            get
            {
                return this.nOTIFICATIONIDField;
            }
            set
            {
                this.nOTIFICATIONIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PRODUCT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public productResponse[] PRODUCTLIST
        {
            get
            {
                return this.pRODUCTLISTField;
            }
            set
            {
                this.pRODUCTLISTField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ConsumeService")]
    public partial class product
    {
        
        private string gTINField;
        
        private string snField;
        
        private string bnField;
        
        private System.DateTime xdField;
        
        private bool xdFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string GTIN
        {
            get
            {
                return this.gTINField;
            }
            set
            {
                this.gTINField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string SN
        {
            get
            {
                return this.snField;
            }
            set
            {
                this.snField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string BN
        {
            get
            {
                return this.bnField;
            }
            set
            {
                this.bnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=3)]
        public System.DateTime XD
        {
            get
            {
                return this.xdField;
            }
            set
            {
                this.xdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool XDSpecified
        {
            get
            {
                return this.xdFieldSpecified;
            }
            set
            {
                this.xdFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ConsumeService")]
    public partial class consumeServiceRequest
    {
        
        private product[] pRODUCTLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PRODUCT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public product[] PRODUCTLIST
        {
            get
            {
                return this.pRODUCTLISTField;
            }
            set
            {
                this.pRODUCTLISTField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dtts.sfda.gov.sa/ConsumeService", ConfigurationName="ConsumeProductService.ConsumeService")]
    public interface ConsumeService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/ConsumeService/ConsumeService/notifyConsumeRequest", ReplyAction="http://dtts.sfda.gov.sa/ConsumeService/ConsumeService/notifyConsumeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ConsumeProductService.faultBean), Action="http://dtts.sfda.gov.sa/ConsumeService/ConsumeService/notifyConsume/Fault/Service" +
            "Error", Name="ServiceError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ConsumeProductService.notifyConsumeResponse notifyConsume(ConsumeProductService.notifyConsumeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/ConsumeService/ConsumeService/notifyConsumeRequest", ReplyAction="http://dtts.sfda.gov.sa/ConsumeService/ConsumeService/notifyConsumeResponse")]
        System.Threading.Tasks.Task<ConsumeProductService.notifyConsumeResponse> notifyConsumeAsync(ConsumeProductService.notifyConsumeRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyConsumeRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/ConsumeService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ConsumeProductService.consumeServiceRequest ConsumeServiceRequest;
        
        public notifyConsumeRequest()
        {
        }
        
        public notifyConsumeRequest(ConsumeProductService.consumeServiceRequest ConsumeServiceRequest)
        {
            this.ConsumeServiceRequest = ConsumeServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyConsumeResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/ConsumeService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ConsumeProductService.consumeServiceResponse ConsumeServiceResponse;
        
        public notifyConsumeResponse()
        {
        }
        
        public notifyConsumeResponse(ConsumeProductService.consumeServiceResponse ConsumeServiceResponse)
        {
            this.ConsumeServiceResponse = ConsumeServiceResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ConsumeServiceChannel : ConsumeProductService.ConsumeService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class ConsumeServiceClient : System.ServiceModel.ClientBase<ConsumeProductService.ConsumeService>, ConsumeProductService.ConsumeService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ConsumeServiceClient() : 
                base(ConsumeServiceClient.GetDefaultBinding(), ConsumeServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.ConsumeService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ConsumeServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ConsumeServiceClient.GetBindingForEndpoint(endpointConfiguration), ConsumeServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ConsumeServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ConsumeServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ConsumeServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ConsumeServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ConsumeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ConsumeProductService.notifyConsumeResponse notifyConsume(ConsumeProductService.notifyConsumeRequest request)
        {
            return base.Channel.notifyConsume(request);
        }
        
        public System.Threading.Tasks.Task<ConsumeProductService.notifyConsumeResponse> notifyConsumeAsync(ConsumeProductService.notifyConsumeRequest request)
        {
            return base.Channel.notifyConsumeAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.ConsumeService))
            {
                // System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode.TransportCredentialOnly);
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
            if ((endpointConfiguration == EndpointConfiguration.ConsumeService))
            {
                return new System.ServiceModel.EndpointAddress("http://tandtwstest.sfda.gov.sa:8080/ws/ConsumeService/ConsumeService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ConsumeServiceClient.GetBindingForEndpoint(EndpointConfiguration.ConsumeService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ConsumeServiceClient.GetEndpointAddress(EndpointConfiguration.ConsumeService);
        }
        
        public enum EndpointConfiguration
        {
            
            ConsumeService,
        }
    }
}
