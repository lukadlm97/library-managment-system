using LibraryData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryServices
{
    public class DataHelpers
    {
        public static IEnumerable<string> HumanizeBizHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach(var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.OpenTime);
                var closeTime = HumanizeTime(time.CloseTime);

                var timeEntry = $"{day} {openTime} to {closeTime}";
                hours.Add(timeEntry);
            }

            return hours;
        }

        private static string HumanizeTime(int openTime)
        {
            return TimeSpan
                .FromHours(openTime)
                .ToString("hh':'mm");
        }

        private static string HumanizeDay(int dayOfWeek)
        {
            return Enum
                .GetName(typeof(DayOfWeek), dayOfWeek-1);
        }
    }
}
