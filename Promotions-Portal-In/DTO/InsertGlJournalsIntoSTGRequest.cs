using System;

namespace Promotions_Portal_In.DTO
{
    public class InsertGlJournalsIntoSTGRequest
    {
        public string GetSPName()
        {
            return "HMG_PP_INT_IN_PKG.INSERT_GL_JOURNALS_INTO_STG";
        }
        public int? P_PROMOTION_PACKAGE_ID { get; set; } = null;
        public string P_BATCH_NUMBER { get; set; } = null;
        public string P_JOURNAL_CATEGORY { get; set; } = null;
        public DateTime? P_ACCOUNTING_DATE { get; set; } = DateTime.Now;
        public decimal? P_LINE_AMOUNT { get; set; } = null;
        public string P_REVENUE_CATEGORY { get; set; } = null;
    }

    public class InsertGlJournalsIntoSTGResponse
    {
        public decimal P_ORACLE_ID { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MESSAGE { get; set; }
    }
}
