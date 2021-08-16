namespace MohemmOut.DTO
{
    public class SendNotificationRequest
    {
        //public string SECRET_KEY
        //{
        //    get { return SECRET_KEY; }
        //    set { SECRET_KEY = "@hmGfCMt@k3n"; }
        //}
        //public int ORACLE_ID { get; set; }
        //public string EMPLOYEE_NUMBER { get; set; }
        //public string APP_VERSION { get; set; }
        //public string LEGISLATION_CODE { get; set; }
        //public string CREATED_BY
        //{
        //    get { return CREATED_BY; }
        //    set { CREATED_BY = "LYNX"; }
        //}
        //public string ITEM_TYPE { get; set; }
        //public string REQUEST_TYPE { get; set; }
        //public int NOTIFICATION_ID { get; set; }
        //public string SUBJECT { get; set; }
        public string SecretKey { get; set; }
        public int OracleID { get; set; }
        public string EmployeeID { get; set; }
        public string AppVersion { get; set; }
        public string LegislationCode { get; set; }
        public string CreatedBy { get; set; }
        public string ItemType { get; set; }
        public string RequestType { get; set; }
        public int NotificationID { get; set; }
        public string Subject { get; set; }
    }

    public class SendNotificationResponse
    {
        public string MessageStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}
