using System;

namespace APIMiddleware.Core.Extenstion
{
    public static class DateExtension
    {
        public static DateTime GetDateFromString(this string dateString)
        {
            if (!string.IsNullOrEmpty(dateString))
            {
                DateTime result;
                var isValidDate = DateTime.TryParse(dateString, out result);
                return isValidDate ? result : DateTime.MinValue;
            }
            return DateTime.MinValue;
        }

        public static DateTime ToDate(this string datetime)
        {
            DateTime returnData = DateTime.ParseExact(datetime, "dd/MM/yyyy HH:mm", null);
            return returnData;
        }
    }
}
