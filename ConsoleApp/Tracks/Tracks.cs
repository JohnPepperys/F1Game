using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.TrackWorks
{
    internal class TrackWork : ITracks
    {
        Random _random = new Random();

        public TimeSpan RunOneQualifyingLap(ITrackTimes trackTime)
        {
            throw new NotImplementedException();
        }

        public TimeSpan RunOneRaceLap(ITrackTimes trackTime)
        {
            var delta = (int)((trackTime.MaxRaceLap - trackTime.MinRaceLap).TotalMilliseconds);            
            return GenerateOneRaceLapTime(trackTime.MinRaceLap, delta);
        }

        private TimeSpan GenerateOneRaceLapTime(TimeSpan minTime, int delta)
        {
            return minTime + TimeSpan.FromMilliseconds(delta);
        }

    }
}
