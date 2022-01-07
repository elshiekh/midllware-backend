﻿using System.Collections.Generic;

namespace elevatus_out.OrganizationGroup
{

    #region New-OrganizationGroup
    public class OrganizationGroupRequest
    {
        public string system_id { get; set; }
        public string system_code { get; set; }
        public string system_name_en { get; set; }
        public string system_name_ar { get; set; }
        public bool system_status { get; set; }
    }
    public class DeleteOrganizationGroupRequest
    {
        public List<string> system_id { get; set; }
    }
    // Response --------
    public class NewOrganizationGroupResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountOrganizationGroup IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdateOrganizationGroupResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountOrganizationGroup IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeleteOrganizationGroupResponse {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }
    #endregion

    #region GET-OrganizationGroup-RESPONSE

    public class GetOrganizationGroupRequest
    {
    }
    public class GetOrganizationGroupResponse {
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
    public class IntegrateAccount {
        public List<ExtraData> ExtraData { get; set; }
    }

    public class IntegrateAccountOrganizationGroup
    {
        public ExtraData ExtraData { get; set; }
    }
    public class ExtraData
    {
        public int SystemId { get; set; }
        public string SystemCode { get; set; }
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

    public class Parent {}
  
    public class CreateResponseOrganizationGroup
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }

    public class UpdateResponseOrganizationGroup
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }

    public class DeleteResponseOrganizationGroup
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }
    #endregion
}
