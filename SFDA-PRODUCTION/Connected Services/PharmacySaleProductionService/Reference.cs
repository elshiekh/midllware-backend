﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmacySaleProductionService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/PharmacySaleService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/PharmacySaleService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/PharmacySaleService")]
    public partial class pharmacySaleServiceResponse
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/PharmacySaleService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/PharmacySaleService")]
    public partial class pharmacySaleServiceRequest
    {
        
        private string tOGLNField;
        
        private string dOCTORIDField;
        
        private string pATIENTNATIONALIDField;
        
        private string pRESCRIPTIONIDField;
        
        private System.DateTime pRESCRIPTIONDATEField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string DOCTORID
        {
            get
            {
                return this.dOCTORIDField;
            }
            set
            {
                this.dOCTORIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string PATIENTNATIONALID
        {
            get
            {
                return this.pATIENTNATIONALIDField;
            }
            set
            {
                this.pATIENTNATIONALIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string PRESCRIPTIONID
        {
            get
            {
                return this.pRESCRIPTIONIDField;
            }
            set
            {
                this.pRESCRIPTIONIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=4)]
        public System.DateTime PRESCRIPTIONDATE
        {
            get
            {
                return this.pRESCRIPTIONDATEField;
            }
            set
            {
                this.pRESCRIPTIONDATEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dtts.sfda.gov.sa/PharmacySaleService", ConfigurationName="PharmacySaleProductionService.PharmacySaleService")]
    public interface PharmacySaleService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/PharmacySaleService/PharmacySaleService/notifyPharmacySal" +
            "eRequest", ReplyAction="http://dtts.sfda.gov.sa/PharmacySaleService/PharmacySaleService/notifyPharmacySal" +
            "eResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PharmacySaleProductionService.faultBean), Action="http://dtts.sfda.gov.sa/PharmacySaleService/PharmacySaleService/notifyPharmacySal" +
            "e/Fault/ServiceError", Name="ServiceError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        PharmacySaleProductionService.notifyPharmacySaleResponse notifyPharmacySale(PharmacySaleProductionService.notifyPharmacySaleRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/PharmacySaleService/PharmacySaleService/notifyPharmacySal" +
            "eRequest", ReplyAction="http://dtts.sfda.gov.sa/PharmacySaleService/PharmacySaleService/notifyPharmacySal" +
            "eResponse")]
        System.Threading.Tasks.Task<PharmacySaleProductionService.notifyPharmacySaleResponse> notifyPharmacySaleAsync(PharmacySaleProductionService.notifyPharmacySaleRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyPharmacySaleRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/PharmacySaleService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public PharmacySaleProductionService.pharmacySaleServiceRequest PharmacySaleServiceRequest;
        
        public notifyPharmacySaleRequest()
        {
        }
        
        public notifyPharmacySaleRequest(PharmacySaleProductionService.pharmacySaleServiceRequest PharmacySaleServiceRequest)
        {
            this.PharmacySaleServiceRequest = PharmacySaleServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class notifyPharmacySaleResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/PharmacySaleService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public PharmacySaleProductionService.pharmacySaleServiceResponse PharmacySaleServiceResponse;
        
        public notifyPharmacySaleResponse()
        {
        }
        
        public notifyPharmacySaleResponse(PharmacySaleProductionService.pharmacySaleServiceResponse PharmacySaleServiceResponse)
        {
            this.PharmacySaleServiceResponse = PharmacySaleServiceResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface PharmacySaleServiceChannel : PharmacySaleProductionService.PharmacySaleService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class PharmacySaleServiceClient : System.ServiceModel.ClientBase<PharmacySaleProductionService.PharmacySaleService>, PharmacySaleProductionService.PharmacySaleService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public PharmacySaleServiceClient() : 
                base(PharmacySaleServiceClient.GetDefaultBinding(), PharmacySaleServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.PharmacySaleService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PharmacySaleServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(PharmacySaleServiceClient.GetBindingForEndpoint(endpointConfiguration), PharmacySaleServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PharmacySaleServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(PharmacySaleServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PharmacySaleServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(PharmacySaleServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PharmacySaleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public PharmacySaleProductionService.notifyPharmacySaleResponse notifyPharmacySale(PharmacySaleProductionService.notifyPharmacySaleRequest request)
        {
            return base.Channel.notifyPharmacySale(request);
        }
        
        public System.Threading.Tasks.Task<PharmacySaleProductionService.notifyPharmacySaleResponse> notifyPharmacySaleAsync(PharmacySaleProductionService.notifyPharmacySaleRequest request)
        {
            return base.Channel.notifyPharmacySaleAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.PharmacySaleService))
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
            if ((endpointConfiguration == EndpointConfiguration.PharmacySaleService))
            {
                return new System.ServiceModel.EndpointAddress("https://rsd.sfda.gov.sa/ws/PharmacySaleService/PharmacySaleService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return PharmacySaleServiceClient.GetBindingForEndpoint(EndpointConfiguration.PharmacySaleService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return PharmacySaleServiceClient.GetEndpointAddress(EndpointConfiguration.PharmacySaleService);
        }
        
        public enum EndpointConfiguration
        {
            
            PharmacySaleService,
        }
    }
}
