using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.TrackWorks
{
    internal class Australia : ITrackTimes
    {
        public TimeSpan QSector1 => new TimeSpan(0,0,0,26,474);

        public TimeSpan QSector2 => new TimeSpan(0, 0, 0, 17, 315);

        public TimeSpan QSector3 => new TimeSpan(0, 0, 0, 32, 602);

        public TimeSpan MinQualyLap => QSector1 + QSector2 + QSector3;

        public TimeSpan MaxQualyLap => new TimeSpan(0, 0, 1, 19, 714);

        public TimeSpan MinRaceLap => new TimeSpan(0, 0, 1, 20, 135);

        public TimeSpan MaxRaceLap => MinRaceLap * 1.07;

        public int Laps => 58;
        public decimal LapDistance => 5.278M; 
    }
}
