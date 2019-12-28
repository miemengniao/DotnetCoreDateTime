using System;
using System.Collections.ObjectModel;

namespace DotnetCoreDateTime
{
    class Program
    {
        public static void Main()
        {
            DateTime thisDate = new DateTime(2007, 3, 10, 0, 0, 0);
            DateTime dstDate = new DateTime(2007, 6, 10, 0, 0, 0);
            DateTimeOffset thisTime;
            
            thisTime = new DateTimeOffset(dstDate, new TimeSpan(-7, 0, 0));
            ShowPossibleTimeZones(thisTime);

            thisTime = new DateTimeOffset(thisDate, new TimeSpan(-6, 0, 0));  
            ShowPossibleTimeZones(thisTime);

            thisTime = new DateTimeOffset(thisDate, new TimeSpan(+1, 0, 0));
            ShowPossibleTimeZones(thisTime);
        }

        private static void ShowPossibleTimeZones(DateTimeOffset offsetTime)
        {
            TimeSpan offset = offsetTime.Offset;
            ReadOnlyCollection<TimeZoneInfo> timeZones;
                    
            Console.WriteLine("{0} could belong to the following time zones:", 
                                offsetTime.ToString());
            // Get all time zones defined on local system
            timeZones = TimeZoneInfo.GetSystemTimeZones();     
            // Iterate time zones 
            foreach (TimeZoneInfo timeZone in timeZones)
            {
                // Compare offset with offset for that date in that time zone
                if (timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
                    Console.WriteLine("   {0}", timeZone.DisplayName);
            }
            Console.WriteLine();
        } 
    }
}
