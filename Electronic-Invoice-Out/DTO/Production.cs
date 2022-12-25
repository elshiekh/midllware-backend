using Electronic_Invoice_Out.Branch;
using System.Collections.Generic;

namespace Electronic_Invoice_Out.DTO
{
    public class Production
    {

        public class ProductionOnboardingCSIDRequest
        {
            public string compliance_request_id { get; set; }

        }
        public class ProductionOnboardingCSIDResponse
        {
            public string requestID { get; set; }
            public string dispositionMessage { get; set; }
            public string binarySecurityToken { get; set; }
            public string secret { get; set; }
            public List<WarningModel> warnings { get; set; }
            public List<ErrorModel> errors { get; set; }
        }


        public class ProductionRenewalCSIDRequest
        {
            public string csr { get; set; }

        }
        public class ProductionRenewalCSIDResponse
        {
            public string RequestID { get; set; }
            public string TokenType { get; set; }
            public string DispositionMessage { get; set; }
            public string BinarySecurityToken { get; set; }
            public string RequestedSecurityToken { get; set; }
            public string secret { get; set; }
            public List<WarningModel> warnings { get; set; }
            public List<ErrorModel> errors { get; set; }
        }
    }
}
