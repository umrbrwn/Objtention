using System;

namespace Umrbrwn.Objtention
{
    public static class DateUtils
    {
        /// <summary>
        /// Converts date to quarter
        /// </summary>
        /// <param name="date">Given date</param>
        /// <returns>Returns quarter of year from given month</returns>
        public static int ToQuarter(this DateTime date)
        {
            return (date.Month + 2) / 3;
        }

        /// <summary>
        /// Converts this datetime to first half of fiscal year
        /// </summary>
        /// <param name="datetime">Datetime to convert from</param>
        /// <returns>First half of fiscal year</returns>
        public static DateTime ToH1FY(this DateTime datetime)
        {
            if (datetime.Month > FiscalYear.H2EndMonth) return new DateTime(datetime.Year, FiscalYear.H1StartMonth, 1);
            else return new DateTime(datetime.AddYears(-1).Year, FiscalYear.H1StartMonth, 1);
        }

        /// <summary>
        /// Converts this datetime to second half of fiscal year
        /// </summary>
        /// <param name="datetime">Datetime to convert from</param>
        /// <returns>Second half of fiscal year</returns>
        public static DateTime ToH2FY(this DateTime datetime)
        {
            if (datetime.Month > FiscalYear.H2EndMonth) return new DateTime(datetime.AddYears(1).Year, FiscalYear.H2EndMonth, 30);
            else return new DateTime(datetime.Year, FiscalYear.H2EndMonth, 30);
        }
    }
}
