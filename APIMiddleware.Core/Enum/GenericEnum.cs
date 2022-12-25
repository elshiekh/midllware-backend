namespace APIMiddleware.Core.Enum
{
    public class GenericEnum
    {
        public enum RequestReceive
        {
            Week = 1,
            Month,
            ThreeMonth,
            SixMontth
        }

        public enum RequestStatus
        {
            Success = 200,
            Fail = 500
        }

        public enum ProjectCode
        {
            SFDA = 203,
            VIDA_IN = 204,
            VIDA_OUT = 205,
            ONBASE_IN = 206,
            ONBASE_OUT = 207,
            MOHEMMOUT = 208,
            PROMOTIONSPORTALIN = 209,
            EXTERNALPORTALIN = 210
        }
    }
}
