using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClass
{
    public class RaceResult
    {
        private int _trackId;
        public List<StageResultPilot> Q1Result = new List<StageResultPilot> ();
        public List<StageResultPilot> Q2Result = new List<StageResultPilot>();
        public List<StageResultPilot> Q3Result = new List<StageResultPilot>();
        public List<StageResultPilot> RaceRes = new List<StageResultPilot>();

        public RaceResult(int trackid) { 
            _trackId = trackid; 
        }

        public int TrackID { get { return _trackId; } }
    }



    public class StageResultPilot : IComparable<StageResultPilot> 
    {
        int _pilotId;
        int _lapNumDNF;
        bool _isDNF = false;
        TimeSpan _timeResult;
        TimeSpan _bestLapTime;
        int _bestLapNum;

        public StageResultPilot(int pilotId, TimeSpan timeResult)
        {
            _pilotId = pilotId;
            _timeResult = timeResult;
            _bestLapTime = timeResult;
            _bestLapNum = 1;
            if (timeResult == TimeSpan.MinValue)
            {
                _isDNF = true;
                _lapNumDNF = 1;
            }
        }

        public TimeSpan BestLapTime { get { return _bestLapTime; } }

        public int LapNumDNF { get { return _lapNumDNF; } }

        public int BestLapNum { get { return _bestLapNum; } }

        public int PID { get { return _pilotId; } }
        public TimeSpan TimeResult { get { return _timeResult; } }

        public int CompareTo(StageResultPilot? other)
        {
            // если один из пилотов выбыл
            if (this._isDNF || other._isDNF)
            {
                if (this._isDNF && other._isDNF)        // если оба пилота имееют статус вылетел - сравниваем круги вылета
                {
                    if (this._lapNumDNF < other._lapNumDNF)
                        return 1;
                    else if (this._lapNumDNF == other._lapNumDNF)
                        return 0;
                    else
                        return -1;
                }
                else if (this._isDNF)   // наш экземпляр вылетел
                    return 1;
                else                    // другой пилот вылетел 
                    return -1;
            }
            else   // никто из пилотов не вылетел
            {
                if (this._timeResult < other._timeResult)
                    return -1;
                else if (this._timeResult == other._timeResult)
                    return 0;
                else
                    return 1;
            }
        }


        public void AddLapTime(TimeSpan lapres, int lapnum) {
            if (lapres == TimeSpan.MinValue)
            {
                _isDNF = true;
                _lapNumDNF = lapnum;
                return;
            }
            
            _timeResult += lapres;
            if (lapres < _bestLapTime)
            {
                _bestLapTime = lapres;
                _bestLapNum = lapnum;
            }
        }

        public bool IsDNF() => _isDNF;
    }

    public enum RaceWeekendStatus { 
        BeforeChampionshipStart,        // nothing start
        BeforeWeekendStart,             // need choose track, weekend not start 
        FinishQ1,                       // finish qual segm1
        FinishQ2, 
        FinishQ3, 
        FinishRace,                      // finish race.
        FinishChampionship              // finish all championship
    }
}
