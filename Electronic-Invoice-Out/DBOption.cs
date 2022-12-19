namespace Electronic_Invoice_Out
{
    public class DBOption
    {
        public string BaseAddress { get; set; }
        public string JsonFormat { get; set; }
        // HMG ------------------
        public string HMGUserName { get; set; }
        public string HMGPassword { get; set; }
        public string PCSID_HMGUserName { get; set; }
        public string PCSID_HMGPassword { get; set; }

        //CS ---------------------
        public string CSUserName { get; set; }
        public string CSPassword { get; set; }
        public string PCSID_CSUserName { get; set; }
        public string PCSID_CSPassword { get; set; }
        //FM ----------------------
        public string FMUserName { get; set; }
        public string FMPassword { get; set; }
        public string PCSID_FMUserName { get; set; }
        public string PCSID_FMPassword { get; set; }
        //TASW ---------------------
        public string TASWUserName { get; set; }
        public string TASWPassword { get; set; }
        public string PCSID_TASWUserName { get; set; }
        public string PCSID_TASWPassword { get; set; }
    }
}
