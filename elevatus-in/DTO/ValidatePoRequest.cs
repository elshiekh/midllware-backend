namespace elevatus_in.DTO
{
    public class ValidateLoginRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG.VALIDATE_LOGIN";
        }
        public string P_USER_NAME { get; set; } = null;
        public string P_PASSWORD { get; set; } = null;
    }

    public class ValidateLoginResponse
    {
        public string P_MOBILE_NUMBER { get; set; }
        public string P_EMAIL_ADDRESS { get; set; }
        public string P_PASSWORD_EXPIRED { get; set; }
        public string P_PASSWORD_EXPIRED_MSG { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }
}
