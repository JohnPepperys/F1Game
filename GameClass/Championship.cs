using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameClass
{
    public static class Championship
    {
        static bool isInit = false;

        /// teams
        static List<F1Team> _Teams = new List<F1Team>();

        /// <summary>
        /// pilots
        /// </summary>
        static List<F1Pilot> _Pilots = new List<F1Pilot>();

        /// <summary>
        /// tracks
        /// </summary>
        static List<F1Track> _Tracks = new List<F1Track>();

        static Dictionary<int, int> _teamPoint = new Dictionary<int, int>();
        static Dictionary<int, int> _pilotPoint = new Dictionary<int, int>();

        static Queue<int> _tracksQueue = new Queue<int>();

        static List<RaceResult> _eachRaceResult = new List<RaceResult>();
        static int nowRaceOnTrack = -1;
        static RaceWeekendStatus nowStatus = RaceWeekendStatus.BeforeChampionshipStart;

        /// <summary>
        /// method than init and start championship
        /// </summary>
        public static void InitChampionship() {
            _Teams.Clear();
            _Pilots.Clear();
            _Tracks.Clear();
            _pilotPoint.Clear();
            _teamPoint.Clear();
            _tracksQueue.Clear();
            _eachRaceResult.Clear();
            nowRaceOnTrack = -1;

            _Teams.AddRange(GameCommon.InitF1Teams());
            _Pilots.AddRange(GameCommon.InitPilots(_Teams));
            _Tracks.AddRange(GameCommon.InitTracks());

            foreach (var team in _Teams)
                _teamPoint.Add(team.Id, 0);
            foreach (var pilot in _Pilots)
                _pilotPoint.Add(pilot.Number, 0);
            foreach (var tr in _Tracks)
                _tracksQueue.Enqueue(tr.ID);
            isInit = true;
        }

        public static IEnumerable<F1Pilot> GetAllPilots() {
            return _Pilots;
        }

        public static IEnumerable<F1Track> GetAllTracks() => _Tracks;


        public static void NextStage() { 
            switch (nowStatus)
            {
                case RaceWeekendStatus.BeforeChampionshipStart:
                    _startWeekend();
                    break;
                
                case RaceWeekendStatus.FinishQ3:
                    _startRace();
                    break;

                case RaceWeekendStatus.FinishRace:
                    _startWeekend();
                    break;
            }
        }

        // -------------------------------------------------------------------------------------------------------------------------------------------- // 
        // ------------------------------------------------------------ Race -------------------------------------------------------------------------- //

        private static void _startRace() {
            // создаем спискок результатов пилотов 
            List<StageResultPilot> stageResultPilots = new List<StageResultPilot>();
            // ищем количество кругов для данного трека
            var laps = _Tracks.First(x => x.ID == nowRaceOnTrack).laps;
            
            for (int i = 1; i <= laps; i++) {
                // проигрываем каждый круг для пилотов. Если кто из пилотов сломался, далее без него
                if (i == 1)     // если первый круг - там учавствуют все пилоты
                {
                    // результаты одного круга для всех пилотов
                    var resOneLap = MakeOneLapForAllPilots(nowRaceOnTrack, _Pilots.Select(x => x.Number));
                    stageResultPilots.AddRange(resOneLap);
                }
                else          // если не первый круг - там учавствуют не все пилоты, а те которые не сошли на предыдущем круге
                {
                    var resOneLap = MakeOneLapForAllPilots(nowRaceOnTrack, stageResultPilots.Where(x => x.IsDNF() == false).Select(y => y.PID));
                    foreach (var res in resOneLap) {
                        // добавляем время очередного круга к пилотам
                        stageResultPilots.First(x => x.PID == res.PID).AddLapTime(res.TimeResult, i);
                    }
                }
            }

            // теперь сортируем пилотов по времени
            stageResultPilots.Sort();
            var rr = _eachRaceResult.First(x => x.TrackID == nowRaceOnTrack);
            rr.RaceRes = stageResultPilots;
            TimeSpan bestTime = TimeSpan.MaxValue;
            int bestLapNum = 0;
            int bestTimePilot = 0;
            foreach (var st in stageResultPilots) {
                if (st.BestLapTime < bestTime)
                {
                    bestTime = st.BestLapTime;
                    bestLapNum = st.BestLapNum;
                    bestTimePilot = st.PID;
                }
            }

            // начисляем за гонку очки пилотам и их командам - первые 10 получают очки 
            for (int i = 0; i < 10; i++)
            {
                _pilotPoint[stageResultPilots[i].PID] += GameCommon.ResultPoints[i];
                _teamPoint[_Pilots.First(x => x.Number == stageResultPilots[i].PID).Team.Id] += GameCommon.ResultPoints[i];
                
            }
            // после проведения гонки меняем статус
            nowStatus = RaceWeekendStatus.FinishRace;
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------- //
        // ------------------------------------------------------------ Qualification ---------------------------------------------------------------- //

        private static void _startWeekend ()
        {
            if (_tracksQueue.TryDequeue(out nowRaceOnTrack) == false)
                throw new Exception("Finish season!");
            nowStatus = RaceWeekendStatus.BeforeWeekendStart;
        }

        public static (int, RaceWeekendStatus) GetWeekendStatus() {
            return (nowRaceOnTrack, nowStatus);
        }

        public static string GetTrackName(int trackid)
        {
            return _Tracks.First(x => x.ID == trackid).Name;
        }

        public static void MakeQualification(int trackid) {
            if (trackid < 0 || trackid > _Tracks.Count())
                throw new Exception("Error in trackid");

            var rr = _eachRaceResult.FirstOrDefault(x => x.TrackID == trackid);
            if (rr == null)
            {
                rr = new RaceResult(trackid);
                _eachRaceResult.Add(rr);
            }
            
            switch (nowStatus)
            {
                case RaceWeekendStatus.BeforeWeekendStart:
                    // here get q1 segm - допускаютс все пилоты
                    rr.Q1Result = MakeQSegment(trackid, _Pilots.Select(x => x.Number));                    
                    nowStatus = RaceWeekendStatus.FinishQ1;
                    break;
                case RaceWeekendStatus.FinishQ1:
                    // here get q2 serm
                    rr.Q2Result = MakeQSegment(trackid, rr.Q1Result.GetRange(0, 15).Select(x => x.PID));
                    nowStatus = RaceWeekendStatus.FinishQ2;
                    break;
                case RaceWeekendStatus.FinishQ2:
                    // here get q2 serm
                    rr.Q3Result = MakeQSegment(trackid, rr.Q2Result.GetRange(0, 10).Select(x => x.PID));
                    nowStatus = RaceWeekendStatus.FinishQ3;
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Make Q1.
        /// </summary>
        /// <param name="trackid"></param>
        /// <param name="pilotList"></param>
        /// <returns></returns>
        private static List<StageResultPilot> MakeQSegment(int trackid, IEnumerable<int> pilotList) {
            // все делают два круга - берется лучшее время круга.
            var result1 = MakeOneLapForAllPilots(trackid, pilotList);
            var result2 = MakeOneLapForAllPilots(trackid, pilotList);

            var res = new List<StageResultPilot> ();
            for (int i = 0; i < result1.Count(); i++)
                if (result1[i].PID == result2[i].PID)
                    res.Add(new StageResultPilot(result1[i].PID,
                                                 result1[i].TimeResult < result2[i].TimeResult ? result1[i].TimeResult : result2[i].TimeResult)
                           );
                else
                    throw new Exception("Incorrect index!");
            res.Sort();
            return res;
        }


        /// <summary>
        /// Make one qualifing lap for all pilots. 
        /// </summary>
        /// <param name="trackid"></param>
        /// <param name="pilotList"></param>
        /// <returns>Dictionary: <pilotnumber - lap time></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        private static List<StageResultPilot> MakeOneLapForAllPilots(int trackid, IEnumerable<int> pilotList)
        {
            // check income params
            if (trackid < 0 || trackid > _Tracks.Count())
                throw new ArgumentException("Unnormal track ID.");
            if (pilotList == null || pilotList.Count() < 8)
                throw new Exception("Unnormal pilots list");
            var track = _Tracks.First(x => x.ID == trackid);

            // make one lap
            var allResult = new List<StageResultPilot>();
            foreach (var pilotNum in pilotList)
            {
                var pilot = _Pilots.First(x => x.Number == pilotNum);
                var result = MakeOneLap(track, pilot);
                allResult.Add(new StageResultPilot(pilotNum, result));
            }

            // output results
            return allResult;
        }
        
        
        /// <summary>
        /// Make one lap for one pilot
        /// </summary>
        /// <param name="track"></param>
        /// <param name="pilot"></param>
        /// <returns>TimeSpan - time of one lap, if lap was successful. If was crash - return TimeSpan.MinValue </returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static TimeSpan MakeOneLap(F1Track track, F1Pilot pilot)
        {
            if (track == null || pilot == null)
                throw new ArgumentNullException("Track or Pilot is null!");
            var rand = new Random();
            /// check that pilot don't crash on this lap
            var crashchance = rand.Next(1001);
            if (crashchance > 996)
            {
                return TimeSpan.MinValue;
            }
            // calc lap
            (var minTime, var maxTime) = track.GetMinMaxQualifingTime();
            var delta = (int)(maxTime - minTime).TotalMilliseconds;
            return minTime + TimeSpan.FromMilliseconds(rand.Next(delta));
        }

        public static RaceResult GetRaceResultForTrack(int trId) {
            return _eachRaceResult.FirstOrDefault(x => x.TrackID == trId);
        }



        public static IEnumerable<string> GetPilotsStanding()
        {
            List<string> res = new List<string>();
            int position = 1;
            foreach (var pair in _pilotPoint.OrderBy(p => p.Value).Reverse()) {
                res.Add($"{position}.\t{_Pilots.First(x => x.Number == pair.Key).FullName}\t(lrp)\t{pair.Value}");
                position++;
            }
            return res;
        }


        public static IEnumerable<string> GetTeamsStanding()
        {
            List<string> res = new List<string>();
            int position = 1;
            foreach (var pair in _teamPoint.OrderBy(p => p.Value).Reverse())
            {
                res.Add($"{position}.\t{_Teams.First(x => x.Id == pair.Key).Name}\t(lrp)\t{pair.Value}");
                position++;
            }
            return res;
        }
    }
}
