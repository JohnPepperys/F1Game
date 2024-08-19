using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClass
{
    public class PilotPoint : IComparable<PilotPoint>
    {
        // идентификатор пилота
        int _pilotId;

        // сумма его очков за сезон
        int _point;

        // наивысшее место
        int _topPosition;

        // id трека на котором было наивысшее место
        int _topPosTrackId;

        // количество этапов, в которых пилот участвовал
        int stages;


        public int PilotID { get { return _pilotId; } }
        public int Points { get { return _point; } }
        public int TopPosition { get { return _topPosition; } }


        public PilotPoint(int pilotid) {
            _pilotId = pilotid;
            _point = 0;
            _topPosition = 100;
            _topPosTrackId = -1;
            stages = 0;
        }

        public void AddRaceResult(int point, int position, int trackid) {
            _point += point;
            stages++;
            if (position < _topPosition) {
                _topPosition = position;
                _topPosTrackId = trackid;
            }
        }


        public string GetPositionStr()
        {
            return $"{Championship.GetAllPilots().First(x => x.Number == _pilotId).FullName} \t\t {_point} \t\t {_topPosition}";
        }


        public int CompareTo(PilotPoint? other)
        {
            if (other == null)
                return 1;
            var res = other.Points - this.Points;
            if (res != 0)
                return res;
            else
            {
                if (this.TopPosition == other.TopPosition)
                    return 0;
                else
                    return (this.TopPosition - other.TopPosition);
            }
        }
    }


    public class DisplayPilotPosition
    {
        public int pos { get; set; }
        public string name { get; set; }
        public int pnum { get; set; }
        public int point { get; set; }
        public int top { get; set; }
        public string team { get; set; }
    }


    public class DisplayTeamPosition
    {
        public int pos { get; set; }
        public string name { get; set; }
        public int point { get; set; }
        public int last { get; set; }
    }
}
