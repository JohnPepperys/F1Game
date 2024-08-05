using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClass
{
    public class F1Track
    {
        private const long MAX_TIME_IN_PERSENT = 116;

        int _id;
        public int ID { get { return _id; } }   
        
        string _name;
        public string Name { get { return _name; } }

        string _country;
        public string Country { get { return _country; } }

        long _distance;
        public long Distance { get { return _distance; } }

        int _laps;
        public int laps { get { return _laps; } }

        TimeSpan _qualifyMinTime;
        TimeSpan _qualifyMaxTime;

        TimeSpan _raceMinTime;
        TimeSpan _raceMaxTime;

        bool _isCityTrack;
        public bool IsCityTrack { get { return _isCityTrack; } }

        public F1Track(int id, string name, string country, long dist, int laps, TimeSpan qtime, TimeSpan raceTime, bool iscity) { 
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(country))
                throw new ArgumentNullException("name or country");
            if (dist < 250000 || dist > 400000)
                throw new ArgumentOutOfRangeException("incorrect dist parameter");
            if (laps < 30 || laps > 100)
                throw new ArgumentOutOfRangeException("incorrect laps parameter");
            var oneminute = new TimeSpan(0, 1, 0);
            if (qtime < oneminute || raceTime < oneminute || raceTime <= qtime)
                throw new ArgumentOutOfRangeException("incorrect qtime or raceTime parameter");
            if (id < 0)
                throw new ArgumentOutOfRangeException("incorrect id parameter");

            _name = name;
            _country = country;
            _distance = dist;
            _laps = laps;
            _qualifyMinTime = qtime;
            _raceMinTime = raceTime;
            _isCityTrack = iscity;
            _id = id;
            _qualifyMaxTime = TimeSpan.FromTicks(_qualifyMinTime.Ticks * MAX_TIME_IN_PERSENT / 100);
            _raceMaxTime = TimeSpan.FromTicks(_raceMinTime.Ticks * MAX_TIME_IN_PERSENT / 100);
        }

        public (TimeSpan, TimeSpan) GetMinMaxQualifingTime() => (_qualifyMinTime, _qualifyMaxTime);
    }
}
