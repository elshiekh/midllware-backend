﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductDispatchDetailService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/DispatchDetailService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/DispatchDetailService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/DispatchDetailService")]
    public partial class dispatchDetailServiceResponse
    {
        
        private string dISPATCHNOTIFICATIONIDField;
        
        private System.DateTime nOTIFICATIONDATEField;
        
        private bool nOTIFICATIONDATEFieldSpecified;
        
        private string fROMGLNField;
        
        private string tOGLNField;
        
        private productResponse[] pRODUCTLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string DISPATCHNOTIFICATIONID
        {
            get
            {
                return this.dISPATCHNOTIFICATIONIDField;
            }
            set
            {
                this.dISPATCHNOTIFICATIONIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=1)]
        public System.DateTime NOTIFICATIONDATE
        {
            get
            {
                return this.nOTIFICATIONDATEField;
            }
            set
            {
                this.nOTIFICATIONDATEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NOTIFICATIONDATESpecified
        {
            get
            {
                return this.nOTIFICATIONDATEFieldSpecified;
            }
            set
            {
                this.nOTIFICATIONDATEFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string FROMGLN
        {
            get
            {
                return this.fROMGLNField;
            }
            set
            {
                this.fROMGLNField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string TOGLN
        {
            get
            {
                return this.tOGLNField;
            }
            set
            {
                this.tOGLNField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/DispatchDetailService")]
    public partial class dispatchDetailServiceRequest
    {
        
        private string dISPATCHNOTIFICATIONIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string DISPATCHNOTIFICATIONID
        {
            get
            {
                return this.dISPATCHNOTIFICATIONIDField;
            }
            set
            {
                this.dISPATCHNOTIFICATIONIDField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dtts.sfda.gov.sa/DispatchDetailService", ConfigurationName="ProductDispatchDetailService.DispatchDetailService")]
    public interface DispatchDetailService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/DispatchDetailService/DispatchDetailService/notifyAcceptR" +
            "equest", ReplyAction="http://dtts.sfda.gov.sa/DispatchDetailService/DispatchDetailService/notifyAcceptR" +
            "esponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ProductDispatchDetailService.faultBean), Action="http://dtts.sfda.gov.sa/DispatchDetailService/DispatchDetailService/notifyAccept/" +
            "Fault/ServiceError", Name="ServiceError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ProductDispatchDetailService.notifyAcceptResponse notifyAccept(ProductDispatchDetailService.notifyAcceptRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/DispatchDetailService/DispatchDetailService/notifyAcceptR" +
            "equest", ReplyAction="http://dtts.sfda.gov.sa/DispatchDetailService/DispatchDetailService/notifyAcceptR" +
            "esponse")]
        System.Threading.Tasks.Task<ProductDispatchDetailService.notifyAcceptResponse> notifyAcceptAsync(ProductDispatchDetailService.notifyAcceptRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyAcceptRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/DispatchDetailService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ProductDispatchDetailService.dispatchDetailServiceRequest DispatchDetailServiceRequest;
        
        public notifyAcceptRequest()
        {
        }
        
        public notifyAcceptRequest(ProductDispatchDetailService.dispatchDetailServiceRequest DispatchDetailServiceRequest)
        {
            this.DispatchDetailServiceRequest = DispatchDetailServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyAcceptResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/DispatchDetailService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ProductDispatchDetailService.dispatchDetailServiceResponse AcceptDispatchNotificationServiceResponse;
        
        public notifyAcceptResponse()
        {
        }
        
        public notifyAcceptResponse(ProductDispatchDetailService.dispatchDetailServiceResponse AcceptDispatchNotificationServiceResponse)
        {
            this.AcceptDispatchNotificationServiceResponse = AcceptDispatchNotificationServiceResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface DispatchDetailServiceChannel : ProductDispatchDetailService.DispatchDetailService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class DispatchDetailServiceClient : System.ServiceModel.ClientBase<ProductDispatchDetailService.DispatchDetailService>, ProductDispatchDetailService.DispatchDetailService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DispatchDetailServiceClient() : 
                base(DispatchDetailServiceClient.GetDefaultBinding(), DispatchDetailServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.DispatchDetailService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DispatchDetailServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(DispatchDetailServiceClient.GetBindingForEndpoint(endpointConfiguration), DispatchDetailServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DispatchDetailServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DispatchDetailServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DispatchDetailServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DispatchDetailServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DispatchDetailServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ProductDispatchDetailService.notifyAcceptResponse notifyAccept(ProductDispatchDetailService.notifyAcceptRequest request)
        {
            return base.Channel.notifyAccept(request);
        }
        
        public System.Threading.Tasks.Task<ProductDispatchDetailService.notifyAcceptResponse> notifyAcceptAsync(ProductDispatchDetailService.notifyAcceptRequest request)
        {
            return base.Channel.notifyAcceptAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.DispatchDetailService))
            {
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
            if ((endpointConfiguration == EndpointConfiguration.DispatchDetailService))
            {
                return new System.ServiceModel.EndpointAddress("http://tandtwstest.sfda.gov.sa:8080/ws/DispatchDetailService/DispatchDetailServic" +
                        "e");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return DispatchDetailServiceClient.GetBindingForEndpoint(EndpointConfiguration.DispatchDetailService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return DispatchDetailServiceClient.GetEndpointAddress(EndpointConfiguration.DispatchDetailService);
        }
        
        public enum EndpointConfiguration
        {
            
            DispatchDetailService,
        }
    }
}