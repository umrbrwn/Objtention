using System;

namespace Objtention
{
    /// <summary>
    /// Represents a named month
    /// </summary>
    public struct FYMonth
    {
        private int _month;

        public FYMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException("Invalid month value provided");

            this._month = month;
        }

        public int Month => this._month;

        public override string ToString()
        {
            return new DateTime(2000, this._month, 1).ToString("MMM").ToUpper();
        }

        public override int GetHashCode()
        {
            return this.Month.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(FYMonth x, FYMonth y)
        {
            return x.Month == y.Month;
        }

        public static bool operator !=(FYMonth x, FYMonth y)
        {
            return x.Month != y.Month;
        }
    }
}
