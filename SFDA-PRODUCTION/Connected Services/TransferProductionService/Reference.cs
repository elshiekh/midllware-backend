﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransferProductionService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/TransferService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/TransferService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/TransferService")]
    public partial class transferServiceResponse
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/TransferService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/TransferService")]
    public partial class transferServiceRequest
    {
        
        private string tOGLNField;
        
        private product[] pRODUCTLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
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
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dtts.sfda.gov.sa/TransferService", ConfigurationName="TransferProductionService.TransferService")]
    public interface TransferService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/TransferService/TransferService/notifyTransferRequest", ReplyAction="http://dtts.sfda.gov.sa/TransferService/TransferService/notifyTransferResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(TransferProductionService.faultBean), Action="http://dtts.sfda.gov.sa/TransferService/TransferService/notifyTransfer/Fault/Serv" +
            "iceError", Name="ServiceError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TransferProductionService.notifyTransferResponse notifyTransfer(TransferProductionService.notifyTransferRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/TransferService/TransferService/notifyTransferRequest", ReplyAction="http://dtts.sfda.gov.sa/TransferService/TransferService/notifyTransferResponse")]
        System.Threading.Tasks.Task<TransferProductionService.notifyTransferResponse> notifyTransferAsync(TransferProductionService.notifyTransferRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyTransferRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/TransferService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public TransferProductionService.transferServiceRequest TransferServiceRequest;
        
        public notifyTransferRequest()
        {
        }
        
        public notifyTransferRequest(TransferProductionService.transferServiceRequest TransferServiceRequest)
        {
            this.TransferServiceRequest = TransferServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyTransferResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/TransferService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public TransferProductionService.transferServiceResponse TransferServiceResponse;
        
        public notifyTransferResponse()
        {
        }
        
        public notifyTransferResponse(TransferProductionService.transferServiceResponse TransferServiceResponse)
        {
            this.TransferServiceResponse = TransferServiceResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface TransferServiceChannel : TransferProductionService.TransferService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class TransferServiceClient : System.ServiceModel.ClientBase<TransferProductionService.TransferService>, TransferProductionService.TransferService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TransferServiceClient() : 
                base(TransferServiceClient.GetDefaultBinding(), TransferServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.TransferService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransferServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TransferServiceClient.GetBindingForEndpoint(endpointConfiguration), TransferServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransferServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TransferServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransferServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TransferServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransferServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public TransferProductionService.notifyTransferResponse notifyTransfer(TransferProductionService.notifyTransferRequest request)
        {
            return base.Channel.notifyTransfer(request);
        }
        
        public System.Threading.Tasks.Task<TransferProductionService.notifyTransferResponse> notifyTransferAsync(TransferProductionService.notifyTransferRequest request)
        {
            return base.Channel.notifyTransferAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.TransferService))
            {
                //System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                //result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;System.ServiceModel.BasicHttpsBinding result = new System.ServiceModel.BasicHttpsBinding(System.ServiceModel.BasicHttpsSecurityMode.Transport);
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
            if ((endpointConfiguration == EndpointConfiguration.TransferService))
            {
                return new System.ServiceModel.EndpointAddress("https://rsd.sfda.gov.sa/ws/TransferService/TransferService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TransferServiceClient.GetBindingForEndpoint(EndpointConfiguration.TransferService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TransferServiceClient.GetEndpointAddress(EndpointConfiguration.TransferService);
        }
        
        public enum EndpointConfiguration
        {
            
            TransferService,
        }
    }
}
