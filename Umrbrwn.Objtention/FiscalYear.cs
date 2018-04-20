using System;

namespace Umrbrwn.Objtention
{
    /// <summary>
    /// Fiscal year, with actual starting and ending dates of fiscal year
    /// </summary>
    public struct FiscalYear
    {
        private DateTime _h1FY, _h2FY;

        /// <summary>
        /// Fiscal year first half starting month
        /// </summary>
        public const int H1StartMonth = 7;

        /// <summary>
        /// Fiscal year first half ending month
        /// </summary>
        public const int H1EndMonth = 12;

        /// <summary>
        /// Fiscal year second half starting month
        /// </summary>
        public const int H2StartMonth = 1;

        /// <summary>
        /// Fiscal year second half ending month
        /// </summary>
        public const int H2EndMonth = 6;

        /// <param name="h1FY">First calendar year of the fiscal year</param>
        /// <param name="h2FY">Second calendar year of same fiscal year</param>
        public FiscalYear(int h1FY, int h2FY)
        {
            if (h1FY == h2FY || h2FY - h1FY != 1)
            {
                throw new ArgumentException("Invalid years provided");
            }

            _h1FY = new DateTime(h1FY, FiscalYear.H1StartMonth, 1);
            _h2FY = new DateTime(h2FY, FiscalYear.H2EndMonth, 30);
        }

        /// <summary>
        /// Represents current fiscal year based on starting and ending month configuration
        /// </summary>
        public static FiscalYear Now
        {
            get
            {
                FiscalYear now;
                DateTime today = DateTime.Today;
                int month = today.Month;

                if (month >= FiscalYear.H1StartMonth && month <= FiscalYear.H1EndMonth)
                    now = new FiscalYear(today.Year, today.AddYears(1).Year);
                else
                    now = new FiscalYear(today.AddYears(-1).Year, today.Year);

                return now;
            }
        }

        /// <summary>
        /// Date representing start of this fiscal year
        /// </summary>
        public DateTime H1FY { get { return _h1FY; } }

        /// <summary>
        /// Date representing end of this fiscal year
        /// </summary>
        public DateTime H2FY { get { return _h2FY; } }

        /// <summary>
        /// Adds number of years in this fiscal year
        /// </summary>
        /// <param name="value">Number of years to add</param>
        /// <returns>Fiscal year</returns>
        public FiscalYear AddYear(int value)
        {
            DateTime newH1FY = H1FY.AddYears(value);
            DateTime newH2FY = H2FY.AddYears(value);

            FiscalYear fy = new FiscalYear(newH1FY.Year, newH2FY.Year);
            return fy;
        }

        /// <summary>
        /// Converts a hyphen seperated string fiscal year (i.e. "2015-2016") to FiscalYear object
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static FiscalYear Parse(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) throw new ArgumentException(input);

            string[] years = input.Split('-');
            if (years.Length == 0 || years.Length > 2)
                throw new FormatException("Invalid string format provided");

            int h1fy = years[0].ToInt();
            int h2fy = years[1].ToInt();

            var fy = new FiscalYear(h1fy, h2fy);
            return fy;
        }

        public override string ToString()
        {
            return string.Format("Fiscal Year {0} - {1}", _h1FY.Year, _h2FY.Year);
        }

        public override int GetHashCode()
        {
            return H1FY.GetHashCode() ^ H2FY.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(FiscalYear f1, FiscalYear f2)
        {
            return f1.GetHashCode() == f2.GetHashCode();
        }

        public static bool operator !=(FiscalYear f1, FiscalYear f2)
        {
            return f1.GetHashCode() != f2.GetHashCode();
        }
    }
}
