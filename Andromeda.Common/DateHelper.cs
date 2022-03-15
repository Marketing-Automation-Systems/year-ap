using System;
using System.Collections.Generic;
using System.Linq;

namespace Andromeda.Common {

    public static class DateHelper {

        public static DateTime Min(DateTime a, DateTime b) {
            return (a < b) ? a : b;
        }

        public static DateTime Max(DateTime a, DateTime b) {
            return (a > b) ? a : b;
        }

        /**
            Creates a list of dates from "from" until "to", inclusive on both ends, using a single day as step.
         */
        public static IEnumerable<DateTime> DaysInRange(
                                            DateTime from,
                                            DateTime to,
                                            bool reverse = false,
                                            int step = 1
                                            ) {
            if (from == null || to == null) {
                throw new ArgumentNullException("Neither 'from' nor 'to' can be null!");
            }

            if (from.Date > to.Date) {
                yield break;
            }
            var current = reverse ? to.Date : from.Date;
            var end = reverse ? from.Date : to.Date;
            int _step = reverse ? -step : step;

            while (current < end) {
                // Console.WriteLine($"current {current} end {end} step {_step}");
                yield return current;
                current = current.AddDays(_step);
            }

            yield return end;
        }

        public static IEnumerable<(DateTime, DateTime)> GetSemestersRange(DateTime startDate, DateTime endDate) {
            endDate = GetDateOnly(endDate).AddDays(1);
            return Enumerable.Range(0, ((endDate - startDate).Days / 180) + 1)
                       .ToList()
                       .Select(it => (startDate.AddMonths(it * 6), DateHelper.Min(startDate.AddMonths((it + 1) * 6), endDate)));
        }

        public static IEnumerable<(DateTime, DateTime)> GetWeeksRange(DateTime startDate, DateTime endDate) {
            endDate = GetDateOnly(endDate).AddDays(1);
            return Enumerable.Range(0, ((endDate - startDate).Days / 7) + 1)
                       .ToList()
                       .Select(it => (startDate.AddDays(it * 7), DateHelper.Min(startDate.AddDays((it + 1) * 7), endDate)));
        }

        public static DateTime GetDateOnly(DateTime dateTime) {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static DateTime AddTimezoneOffset(DateTime dateTime, string timeZoneId) {
            var dateOnly = GetDateOnly(dateTime);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var offset = timeZoneInfo.GetUtcOffset(dateOnly).Hours;
            return dateOnly.AddHours(-offset);
        }
    }
}
