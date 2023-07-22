using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modulmethods;
namespace TUBAF_Planer.Model
{
    class moduloverlapping
    {
        //Method that looks if a specific module is at the same time span on the same day and turnus like a list of modules if yes it returns true if not it returns false
        public bool AnotherModuleIsAtSameTime(Modul testmodul, List<Modul> modullist)
        {
            // Check if the otherModule overlaps with any module in the modullist
            foreach (var module in modullist)
            {
                // Skip comparing the otherModule with itself
                if (ReferenceEquals(module, testmodul))
                {
                    return true;
                }
                if (testmodul.Weekday == null)
                {
                    continue;
                }
                // Check if the modules have the same weekday and turnus (if turnus is not null)
                if (module.Weekday != testmodul.Weekday)
                {
                    continue;
                }
                // Check if the modules have the same turnus (if turnus is not null)  
                if (!((testmodul.Turnus == "wöchentlich" || module.Turnus == "wöchentlich") || (testmodul.Turnus == module.Turnus)))
                {
                    continue;
                }
                if (module.Start != null && module.End != null && testmodul.Start != null && testmodul.End != null)
                {
                    // Parse the time strings to TimeSpan objects for easier comparison
                    TimeSpan moduleStartTime = TimeSpan.Parse(module.Start);
                    TimeSpan moduleEndTime = TimeSpan.Parse(module.End);
                    TimeSpan otherModuleStartTime = TimeSpan.Parse(testmodul.Start);
                    TimeSpan otherModuleEndTime = TimeSpan.Parse(testmodul.End);

                    // Check if there is an overlap in the time span
                    if ((moduleStartTime < otherModuleEndTime && moduleEndTime > otherModuleStartTime) ||
                        (otherModuleStartTime < moduleEndTime && otherModuleEndTime > moduleStartTime))
                    {
                        return true; // Overlap found
                    }
                }
            }
            return false; // No overlap found
        }
    }
}
