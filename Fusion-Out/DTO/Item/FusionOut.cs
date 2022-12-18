using System.Collections.Generic;

namespace Fusion_Out.FusionOut
{

    #region UpdateStatusCallback
    public class UpdateStatusCallbackRequest
    {
        public string transaction_id { get; set; }
        public string ebs_id { get; set; }
        public string status { get; set; }
        public string status_description { get; set; }
    }


    // Response --------
    public class UpdateStatusCallbackResponse
    {
        public string status { get; set; }
        public string status_message { get; set; }
        //public string error_description { get; set; }
    }
    #endregion

}
