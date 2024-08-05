using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.TrackWorks
{
    internal interface ITracks
    {
        TimeSpan RunOneQualifyingLap(ITrackTimes trackTimes);
        
        TimeSpan RunOneRaceLap(ITrackTimes trackTime);
    }
}
