using System;

namespace HMGOnBaseIn.DTO
{
    public class GetBankBranchRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_BANK_BRANCHES";
        }
        public int P_BANK_PARTY_ID { get; set; }
    }

    public class GetBankBranchResponse
    {
        public Int64 BANK_BRANCH_ID { get; set; }
        public string BANK_BRANCH_NAME { get; set; }
    }
}
