﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductImportService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ImportService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ImportService")]
    public partial class snResponse
    {
        
        private string snField;
        
        private string rcField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ImportService")]
    public partial class importServiceResponse
    {
        
        private string gTINField;
        
        private string bnField;
        
        private System.DateTime mdField;
        
        private bool mdFieldSpecified;
        
        private System.DateTime xdField;
        
        private bool xdFieldSpecified;
        
        private long nOTIFICATIONIDField;
        
        private snResponse[] sNRESPONSELISTField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=2)]
        public System.DateTime MD
        {
            get
            {
                return this.mdField;
            }
            set
            {
                this.mdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MDSpecified
        {
            get
            {
                return this.mdFieldSpecified;
            }
            set
            {
                this.mdFieldSpecified = value;
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
        public long NOTIFICATIONID
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
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SNRESPONSE", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public snResponse[] SNRESPONSELIST
        {
            get
            {
                return this.sNRESPONSELISTField;
            }
            set
            {
                this.sNRESPONSELISTField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/ImportService")]
    public partial class importServiceRequest
    {
        
        private System.DateTime mdField;
        
        private string gTINField;
        
        private System.DateTime xdField;
        
        private string bnField;
        
        private string[] sNREQUESTLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=0)]
        public System.DateTime MD
        {
            get
            {
                return this.mdField;
            }
            set
            {
                this.mdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
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
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SN", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public string[] SNREQUESTLIST
        {
            get
            {
                return this.sNREQUESTLISTField;
            }
            set
            {
                this.sNREQUESTLISTField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dtts.sfda.gov.sa/ImportService", ConfigurationName="ProductImportService.ImportService")]
    public interface ImportService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/ImportService/ImportService/notifyImportRequest", ReplyAction="http://dtts.sfda.gov.sa/ImportService/ImportService/notifyImportResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ProductImportService.faultBean), Action="http://dtts.sfda.gov.sa/ImportService/ImportService/notifyImport/Fault/ServiceErr" +
            "or", Name="ServiceError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ProductImportService.notifyImportResponse notifyImport(ProductImportService.notifyImportRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/ImportService/ImportService/notifyImportRequest", ReplyAction="http://dtts.sfda.gov.sa/ImportService/ImportService/notifyImportResponse")]
        System.Threading.Tasks.Task<ProductImportService.notifyImportResponse> notifyImportAsync(ProductImportService.notifyImportRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyImportRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/ImportService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ProductImportService.importServiceRequest ImportServiceRequest;
        
        public notifyImportRequest()
        {
        }
        
        public notifyImportRequest(ProductImportService.importServiceRequest ImportServiceRequest)
        {
            this.ImportServiceRequest = ImportServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyImportResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/ImportService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ProductImportService.importServiceResponse ImportServiceResponse;
        
        public notifyImportResponse()
        {
        }
        
        public notifyImportResponse(ProductImportService.importServiceResponse ImportServiceResponse)
        {
            this.ImportServiceResponse = ImportServiceResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ImportServiceChannel : ProductImportService.ImportService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class ImportServiceClient : System.ServiceModel.ClientBase<ProductImportService.ImportService>, ProductImportService.ImportService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ImportServiceClient() : 
                base(ImportServiceClient.GetDefaultBinding(), ImportServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.ImportService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ImportServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ImportServiceClient.GetBindingForEndpoint(endpointConfiguration), ImportServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ImportServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ImportServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ImportServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ImportServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ImportServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ProductImportService.notifyImportResponse notifyImport(ProductImportService.notifyImportRequest request)
        {
            return base.Channel.notifyImport(request);
        }
        
        public System.Threading.Tasks.Task<ProductImportService.notifyImportResponse> notifyImportAsync(ProductImportService.notifyImportRequest request)
        {
            return base.Channel.notifyImportAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.ImportService))
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
            if ((endpointConfiguration == EndpointConfiguration.ImportService))
            {
                return new System.ServiceModel.EndpointAddress("http://tandtwstest.sfda.gov.sa:8080/ws/ImportService/ImportService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ImportServiceClient.GetBindingForEndpoint(EndpointConfiguration.ImportService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ImportServiceClient.GetEndpointAddress(EndpointConfiguration.ImportService);
        }
        
        public enum EndpointConfiguration
        {
            
            ImportService,
        }
    }
}