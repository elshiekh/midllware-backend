using System;

namespace HMGOnBaseIn.DTO
{
    public class LoginRequest
    {
        public int P_MBL_ID { get; set; }
        public string P_USER_NAME { get; set; }
        public string P_LANGUAGE { get; set; }
        public string P_PASSWORD { get; set; }
        //public int P_SESSION_ID { get; set; }
        //public string P_PASSWORD_EXPIRED { get; set; }
        //public string P_PASSWORD_EXPIRED_MSG { get; set; }
        //public string P_INVALID_LOGINS_MSG { get; set; }
        //public string P_RETURN_STATUS { get; set; }
        //public string P_RETURN_MSG { get; set; }

        public string GetSPName()
        {
            return "MBL_APP_PKG.LOGIN";
        }
    }
    public class LoginResponse
    {
        public Decimal P_SESSION_ID { get; set; }
        public string P_PASSWORD_EXPIRED { get; set; }
        public string P_PASSWORD_EXPIRED_MSG { get; set; }
        public string P_INVALID_LOGINS_MSG { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }
}
