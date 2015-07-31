using System;

namespace Leanwork.CodePack
{
    public static class DateTimeExtensions
    {
        public static bool InRange(this DateTime date, 
            DateTime? dateStart, DateTime? dateEnd, bool include = true)
        {
            if (dateStart.HasValue == false || dateEnd.HasValue == false)
                return false;

            return InRange(date, dateStart.Value, dateEnd.Value);
        }

        public static bool InRange(this DateTime date, 
            DateTime dateStart, DateTime dateEnd, bool include = true)
        {
            DateTime start = DateTime.SpecifyKind(dateStart, DateTimeKind.Local);
            if ((include && start.CompareTo(date) >= 0) || start.CompareTo(date) > 0)
                return false;

            DateTime end = DateTime.SpecifyKind(dateEnd, DateTimeKind.Local);
            if ((include && end.CompareTo(date) <= 0) || end.CompareTo(date) < 0)
                return false;

            return true;
        }

        public static Int64 Diff(this DateTime? dateStart, String datePart, DateTime dateEnd)
        {
            if (dateStart.HasValue == false)
                return 0;

            return Diff(dateStart.Value, datePart, dateEnd);
        }

        public static Int64 Diff(this DateTime dateStart, String datePart, DateTime dateEnd)
        {
            Int64 DateDiffVal = 0;
            System.Globalization.Calendar cal = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            TimeSpan ts = new TimeSpan(dateEnd.Ticks - dateStart.Ticks);
            switch (datePart.ToLower().Trim())
            {
                #region year
                case "year":
                case "yy":
                case "yyyy":
                    DateDiffVal = (Int64)(cal.GetYear(dateEnd) - cal.GetYear(dateStart));
                    break;
                #endregion

                #region quarter
                case "quarter":
                case "qq":
                case "q":
                    DateDiffVal = (Int64)((((cal.GetYear(dateEnd)
                                        - cal.GetYear(dateStart)) * 4)
                                        + ((cal.GetMonth(dateEnd) - 1) / 3))
                                        - ((cal.GetMonth(dateStart) - 1) / 3));
                    break;
                #endregion

                #region month
                case "month":
                case "mm":
                case "m":
                    DateDiffVal = (Int64)(((cal.GetYear(dateEnd)
                                        - cal.GetYear(dateStart)) * 12
                                        + cal.GetMonth(dateEnd))
                                        - cal.GetMonth(dateStart));
                    break;
                #endregion

                #region day
                case "day":
                case "d":
                case "dd":
                    DateDiffVal = (Int64)ts.TotalDays;
                    break;
                #endregion

                #region week
                case "week":
                case "wk":
                case "ww":
                    DateDiffVal = (Int64)(ts.TotalDays / 7);
                    break;
                #endregion

                #region hour
                case "hour":
                case "hh":
                    DateDiffVal = (Int64)ts.TotalHours;
                    break;
                #endregion

                #region minute
                case "minute":
                case "mi":
                case "n":
                    DateDiffVal = (Int64)ts.TotalMinutes;
                    break;
                #endregion

                #region second
                case "second":
                case "ss":
                case "s":
                    DateDiffVal = (Int64)ts.TotalSeconds;
                    break;
                #endregion

                #region millisecond
                case "millisecond":
                case "ms":
                    DateDiffVal = (Int64)ts.TotalMilliseconds;
                    break;
                #endregion

                default:
                    throw new Exception(String.Format("DatePart \"{0}\" is unknown", datePart));
            }
            return DateDiffVal;
        }

        public static bool IsWeekend(this DayOfWeek d)
        {
            return !d.IsWeekday();
        }

        public static bool IsWeekday(this DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday: return false;

                default: return true;
            }
        }

        public static DateTime AddWorkDays(this DateTime d, int days)
        {
            // start from a weekday
            while (d.DayOfWeek.IsWeekday()) d = d.AddDays(1.0);
            for (int i = 0; i < days; ++i)
            {
                d = d.AddDays(1.0);
                while (d.DayOfWeek.IsWeekday()) d = d.AddDays(1.0);
            }
            return d;
        }

        static public int Age(this DateTime dateOfBirth)
        {
            if (DateTime.Today.Month < dateOfBirth.Month || DateTime.Today.Month == dateOfBirth.Month && DateTime.Today.Day < dateOfBirth.Day)
                return DateTime.Today.Year - dateOfBirth.Year - 1;
            else
                return DateTime.Today.Year - dateOfBirth.Year;
        }

        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstOfTheMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Returns a formatted date or emtpy string
        /// </summary>
        /// <param name="t">DateTime instance or null</param>
        /// <param name="format">datetime formatstring </param>
        /// <returns></returns>
        public static string ToString(this DateTime? t, string format)
        {
            if (t != null)
                return t.Value.ToString(format);

            return "";
        }
    }
}
