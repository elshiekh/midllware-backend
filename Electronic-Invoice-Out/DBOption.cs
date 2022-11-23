namespace Electronic_Invoice_Out
{
    public class DBOption
    {
        public string BaseAddress { get; set; }
        public string JsonFormat { get; set; }
        // HMG
        public string HMGUserName { get; set; }
        public string HMGPassword { get; set; }
        //PCSID-HMG
        public string PCSID_HMGUserName { get; set; }
        public string PCSID_HMGPassword { get; set; }

        public string CSUserName { get; set; }
        public string CSPassword { get; set; }
        public string FMUserName { get; set; }
        public string FMPassword { get; set; }

    }
}
