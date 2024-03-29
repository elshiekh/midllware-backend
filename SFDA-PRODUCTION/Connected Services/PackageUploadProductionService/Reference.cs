﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageUploadProductionService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/PackageUploadService")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/PackageUploadService")]
    public partial class packageUploadServiceResponse
    {
        
        private long tRANSFERIDField;
        
        private string mD5CHECKSUMField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public long TRANSFERID
        {
            get
            {
                return this.tRANSFERIDField;
            }
            set
            {
                this.tRANSFERIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string MD5CHECKSUM
        {
            get
            {
                return this.mD5CHECKSUMField;
            }
            set
            {
                this.mD5CHECKSUMField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dtts.sfda.gov.sa/PackageUploadService")]
    public partial class packageUploadServiceRequest
    {
        
        private string tOGLNField;
        
        private byte[] fILEField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", Order=1)]
        public byte[] FILE
        {
            get
            {
                return this.fILEField;
            }
            set
            {
                this.fILEField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dtts.sfda.gov.sa/PackageUploadService", ConfigurationName="PackageUploadProductionService.PackageUploadService")]
    public interface PackageUploadService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/PackageUploadService/PackageUploadService/uploadFileReque" +
            "st", ReplyAction="http://dtts.sfda.gov.sa/PackageUploadService/PackageUploadService/uploadFileRespo" +
            "nse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PackageUploadProductionService.faultBean), Action="http://dtts.sfda.gov.sa/PackageUploadService/PackageUploadService/uploadFile/Faul" +
            "t/ServiceError", Name="ServiceError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        PackageUploadProductionService.uploadFileResponse uploadFile(PackageUploadProductionService.uploadFileRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dtts.sfda.gov.sa/PackageUploadService/PackageUploadService/uploadFileReque" +
            "st", ReplyAction="http://dtts.sfda.gov.sa/PackageUploadService/PackageUploadService/uploadFileRespo" +
            "nse")]
        System.Threading.Tasks.Task<PackageUploadProductionService.uploadFileResponse> uploadFileAsync(PackageUploadProductionService.uploadFileRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class uploadFileRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/PackageUploadService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public PackageUploadProductionService.packageUploadServiceRequest PackageUploadServiceRequest;
        
        public uploadFileRequest()
        {
        }
        
        public uploadFileRequest(PackageUploadProductionService.packageUploadServiceRequest PackageUploadServiceRequest)
        {
            this.PackageUploadServiceRequest = PackageUploadServiceRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class uploadFileResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://dtts.sfda.gov.sa/PackageUploadService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public PackageUploadProductionService.packageUploadServiceResponse PackageUploadServiceResponse;
        
        public uploadFileResponse()
        {
        }
        
        public uploadFileResponse(PackageUploadProductionService.packageUploadServiceResponse PackageUploadServiceResponse)
        {
            this.PackageUploadServiceResponse = PackageUploadServiceResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface PackageUploadServiceChannel : PackageUploadProductionService.PackageUploadService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class PackageUploadServiceClient : System.ServiceModel.ClientBase<PackageUploadProductionService.PackageUploadService>, PackageUploadProductionService.PackageUploadService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public PackageUploadServiceClient() : 
                base(PackageUploadServiceClient.GetDefaultBinding(), PackageUploadServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.PackageUploadService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PackageUploadServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(PackageUploadServiceClient.GetBindingForEndpoint(endpointConfiguration), PackageUploadServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PackageUploadServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(PackageUploadServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PackageUploadServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(PackageUploadServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PackageUploadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public PackageUploadProductionService.uploadFileResponse uploadFile(PackageUploadProductionService.uploadFileRequest request)
        {
            return base.Channel.uploadFile(request);
        }
        
        public System.Threading.Tasks.Task<PackageUploadProductionService.uploadFileResponse> uploadFileAsync(PackageUploadProductionService.uploadFileRequest request)
        {
            return base.Channel.uploadFileAsync(request);
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
            if ((endpointConfiguration == EndpointConfiguration.PackageUploadService))
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
            if ((endpointConfiguration == EndpointConfiguration.PackageUploadService))
            {
                return new System.ServiceModel.EndpointAddress("https://rsd.sfda.gov.sa/ws/PackageUploadService/PackageUploadService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return PackageUploadServiceClient.GetBindingForEndpoint(EndpointConfiguration.PackageUploadService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return PackageUploadServiceClient.GetEndpointAddress(EndpointConfiguration.PackageUploadService);
        }
        
        public enum EndpointConfiguration
        {
            
            PackageUploadService,
        }
    }
}
