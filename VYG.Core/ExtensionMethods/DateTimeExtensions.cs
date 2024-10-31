namespace VYG.Core.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime StartOfWeek(this DateTime date)
        {
            int diff = (int)date.DayOfWeek - (int)DayOfWeek.Monday;
            return date.AddDays(-diff).Date;
        }

        public static DateTime EndOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
    }
}
