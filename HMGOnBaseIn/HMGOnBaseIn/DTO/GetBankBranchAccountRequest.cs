using System;

namespace HMGOnBaseIn.DTO
{
    public class GetBankBranchAccountRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_BANK_BRANCHE_ACCOUNT";
        }

        public int P_BANK_BRANCH_ID { get; set; }
        public int P_ORGANIZATION_ID { get; set; }
    }
    public class GetBankBranchAccountResponse
    {
        public Int64 BANK_ACCOUNT_ID { get; set; }

        public string BANK_ACCOUNT_NAME { get; set; }

        public string BANK_ACCOUNT_NUM { get; set; }

        public string IBAN_NUMBER { get; set; }
    }

}
