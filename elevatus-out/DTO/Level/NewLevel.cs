using System.Collections.Generic;

namespace elevatus_out.Level
{
    public class LevelRequest
    {
        public string system_id { get; set; }
        public string system_name_en { get; set; }
        public string system_name_ar { get; set; }
        public string system_code { get; set; }
        public bool system_status { get; set; }
    }
    public class DeleteLevelRequest
    {
        public List<string> system_id { get; set; }
    }
    // Response --------
    public class NewLevelResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountLevel IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdateLevelResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountLevel IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeleteLevelResponse
    {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }



    public class GetLevelRequest { }
    public class GetLevelResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccount IntegrateAccount { get; set; }
    }
    public class Identifiers
    {
        public string RequestId { get; set; }
        public string ApplicationId { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public Paginate Paginate { get; set; }
    }

    public class IdentifierDeleteResponse
    {
        public string RequestId { get; set; }
        public string ApplicationId { get; set; }
        public List<IdentifierDeleteResponseAction> Action { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
    }
    public class IdentifierDeleteResponseAction
    {
        public string System_Id { get; set; }
        public string Status { get; set; }
    }
    public class Paginate
    {
        public string Page { get; set; }
        public string Limit { get; set; }
        public string Total { get; set; }
    }
    public class IntegrateAccount
    {
        public List<ExtraData> ExtraData { get; set; }
    }

    public class IntegrateAccountLevel
    {
        public ExtraData ExtraData { get; set; }
    }
    public class ExtraData
    {
        public string SystemId { get; set; }
        public string SystemNameEn { get; set; }
        public string SystemNameAr { get; set; }
        public bool SystemStatus { get; set; }
        public bool CanDelete { get; set; }
    }
    public class Reason
    {
        public string Filed { get; set; }
        public string Type { get; set; }
        public string error { get; set; }
    }

    public class TranslateLevel
    {
        public TranslateLevelArabic ar { get; set; }
        public TranslateLevelEnglish en { get; set; }
    }

    public class TranslateLevelArabic
    {
        public string system_name { get; set; }
    }

    public class TranslateLevelEnglish
    {
        public string system_name { get; set; }
    }

    public class CreateResponseLevel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class UpdateResponseLevel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class DeleteResponseLevel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }
}
