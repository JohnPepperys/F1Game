using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.TrackWorks
{
    internal interface ITrackTimes
    {
        public TimeSpan QSector1 { get; }
        public TimeSpan QSector2 { get; }
        public TimeSpan QSector3 { get; }

        public TimeSpan MinQualyLap { get; }
        public TimeSpan MaxQualyLap { get; }

        public TimeSpan MinRaceLap { get; }
        public TimeSpan MaxRaceLap { get; }

        public int Laps { get; }
        public decimal LapDistance { get; }
    }
}
