using System;

namespace BenchmarkExample
{
    public class DateParser
    {
        public int GetYearFromDateTime(string dateTimeAsString)
        {
            var dateTime = DateTime.Parse(dateTimeAsString);
            return dateTime.Year;
        }

        public int GetYearFromSplit(string dateTimeAsString)
        {
            var splitOnHyphens = dateTimeAsString.Split('-');
            return int.Parse(splitOnHyphens[0]);
        }

        public int GetYearFromSubstring(string dateTimeAsString)
        {
            var indexOfHyphen = dateTimeAsString.IndexOf('-');
            return int.Parse(dateTimeAsString.Substring(0, indexOfHyphen));
        }

        public int GetYearFromSpan(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var indexOfHyphen = dateTimeAsSpan.IndexOf('-');
            return int.Parse(dateTimeAsSpan.Slice(0, indexOfHyphen));
        }

        public int GetYearFromSpanWithManualConversion(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var indexOfHyphen = dateTimeAsSpan.IndexOf('-');
            var yearAsSpan = dateTimeAsSpan.Slice(0, indexOfHyphen);

            var temp = 0;
            for (int i = 0; i < yearAsSpan.Length; i++)
            {
                temp = temp * 10 + (yearAsSpan[i] - '0');
            }

            return temp;
        }
    }
}