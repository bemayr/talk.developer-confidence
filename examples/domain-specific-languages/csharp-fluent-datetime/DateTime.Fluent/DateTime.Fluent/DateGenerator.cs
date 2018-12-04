using System;

namespace Fluent.Dates
{
    public interface IDateGenerator
    {
        DateTime UnixInitial();
        DateTime Christmas(int year);
        DateTime EasterSunday(int year);
    }

    public class DateGenerator : IDateGenerator
    {
        public DateTime UnixInitial() => new DateTime();
        public DateTime Christmas(int year) => new DateTime(year, 12, 24);
        public DateTime EasterSunday(int year)
        {
            var k = year / 100;
            var m = 15 + (3 * k + 3) / 4 - (8 * k + 13) / 25;
            var s = 2 - (3 * k + 3) / 4;
            var a = year % 19;
            var d = (19 * a + m) % 30;
            var r = (d + a / 11) / 29;
            var og = 21 + d - r;
            var sz = 7 - (year + year / 4 + s) % 7;
            var oe = 7 - (og - sz) % 7;
            var os = og + oe;
            return new DateTime(year, 3 + os / 31, os % 31);
        }
    }
}
