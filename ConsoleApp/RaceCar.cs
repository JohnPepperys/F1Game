using ConsoleApp.TrackWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class RaceCar
    {
        string _team;
        string _racerName;
        List<TimeSpan> _laptime = new List<TimeSpan>();
        int _lapCount = 0;
        int _carNumber = 0;
        int _crashlap = 0;
        bool _inRace = true;
        Random _random = new Random();
        ITracks _trackProvider = new TrackWork();

        public RaceCar(string team, string pilot, int num)
        {
            if (String.IsNullOrEmpty(team))
                throw new Exception("Team cannot be null or empty");
            if (String.IsNullOrEmpty(pilot))
                throw new Exception("Driver cannot be null or empty");
            _team = team;            
            _racerName = pilot;
            
            if (num > 0 && num < 100)
                _carNumber = num;
            else
                throw new Exception("Num need between 1 and 99");
        }

        public string Team { get { return _team;  } }
        public string Pilot { get { return _racerName; } }
        public int CarNumber { get { return _carNumber;} }
        public bool RunOneLap(ITrackTimes track)
        {
            // 1 percent chance that will be crash
            var crashchance = _random.Next(1001);
            if (crashchance > 996) {
                _laptime.Add(new TimeSpan(23, 59, 59));
                _inRace = false;
                _crashlap = _lapCount + 1;
                return false;
            }

            _laptime.Add(_trackProvider.RunOneRaceLap(track));
            _lapCount++;
            return true;
        }

        public bool InRace { get { return _inRace; } }

        public TimeSpan GetLastLapTime()
        {
            return _laptime.Last();
        }

        public TimeSpan TotalTime { get { return new TimeSpan(_laptime.Sum(x => x.Ticks)); } }

        public int CrashLap { get { return _crashlap;  } }
    }
}
