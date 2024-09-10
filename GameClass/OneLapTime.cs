using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClass
{
    public static class OneLapTime
    {
        /// <summary>
        /// Make time of one lap for one pilot - simple random alghoritm
        /// </summary>
        /// <param name="track"></param>
        /// <param name="pilot"></param>
        /// <returns>TimeSpan - time of one lap, if lap was successful. If was crash - return TimeSpan.MinValue </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TimeSpan MakeOneLap_RandomTime(F1Track track, F1Pilot pilot)
        {
            if (track == null || pilot == null)
                throw new ArgumentNullException("Track or Pilot is null!");
            var rand = new Random();

            /// check that pilot don't crash on this lap
            var crashchance = rand.Next(1001);
            if (crashchance > 996)      // коэффициент, подобран империческим путем
            {
                return TimeSpan.MinValue;
            }

            // calc lap
            (var minTime, var maxTime) = track.GetMinMaxQualifingTime();
            var delta = (int)(maxTime - minTime).TotalMilliseconds;
            return minTime + TimeSpan.FromMilliseconds(rand.Next(delta));
        }



        /// <summary>
        /// Make time of ONE qualifying lap for ONE pilot - algoritm that based on pilot expirience
        /// </summary>
        /// <param name="track"></param>
        /// <param name="pilot"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TimeSpan MakeOneQualifyingLap_PilotExpirience(F1Track track, F1Pilot pilot)
        {
            if (track == null || pilot == null)
                throw new ArgumentNullException("Track or Pilot is null!");
            var rand = new Random();

            /// check that pilot don't crash on this lap
            var crashchance = rand.Next(1001);
            if (crashchance > 996)      // коэффициент, подобран империческим путем
            {
                return TimeSpan.MinValue;
            }

            // calc lap
            (var minTime, var maxTime) = track.GetMinMaxQualifingTime();
            maxTime = TimeSpan.FromTicks(minTime.Ticks * 104 / 100);        // разницу между максимальным и минимальным берем как 104 процента
            var delta = (maxTime - minTime).TotalMilliseconds;
            
            // делим delta на две части в пропорции 0.35delta и 065delta: меньшая часть она просто случайна, большая часть она случайная, но зависит от опыта
            int delta_part1 = (int)(delta * 0.35 * 100);
            var time1 = TimeSpan.FromMilliseconds(rand.Next(delta_part1) / 100);
            int delta_part2 = (int)(delta * 0.65 * 100);
            var time2 = TimeSpan.FromMilliseconds(rand.Next(delta_part2) / 100);

            // на круге может быть снос авто - выбрасываем некоторую вероятность
            var slideChance = rand.Next(1001);
            TimeSpan timeSlide;
            if (slideChance > 990)
                // добавляем время скольжения от 0.4 до 3 секунд в результат
                timeSlide = TimeSpan.FromMilliseconds(rand.Next(400, 3000));
            else
                timeSlide = TimeSpan.FromMicroseconds(0);
            return minTime + time1 + time2 + timeSlide;
        }



        /// <summary>
        /// Make time of ONE qualifying lap for ONE pilot - algoritm that based on pilot expirience
        /// </summary>
        /// <param name="track"></param>
        /// <param name="pilot"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TimeSpan MakeOneRaceLap_PilotExpirience(F1Track track, F1Pilot pilot)
        {
            if (track == null || pilot == null)
                throw new ArgumentNullException("Track or Pilot is null!");
            var rand = new Random();

            /// check that pilot don't crash on this lap
            var crashchance = rand.Next(1001);
            if (crashchance > 996)      // коэффициент, подобран империческим путем
            {
                return TimeSpan.MinValue;
            }

            // calc lap
            (var minTime, var maxTime) = track.GetMinMaxQualifingTime();
            maxTime = TimeSpan.FromTicks(minTime.Ticks * 108 / 100);        // разницу между максимальным и минимальным берем как 10 процента
            var delta = (maxTime - minTime).TotalMilliseconds;

            // делим delta на две части в пропорции 0.35delta и 065delta: меньшая часть она просто случайна, большая часть она случайная, но зависит от опыта
            int delta_part1 = (int)(delta * 0.35 * 100);
            var time1 = TimeSpan.FromMilliseconds(rand.Next(delta_part1) / 100);
            int delta_part2 = (int)(delta * 0.65 * 100);
            var time2 = TimeSpan.FromMilliseconds((rand.Next(delta_part2) / pilot.Races));

            // на круге может быть снос авто - выбрасываем некоторую вероятность
            var slideChance = rand.Next(1001);
            TimeSpan timeSlide;
            if (slideChance > 980)
                // добавляем время скольжения от 0.4 до 3 секунд в результат
                timeSlide = TimeSpan.FromMilliseconds(rand.Next(400, 3000));
            else
                timeSlide = TimeSpan.FromMicroseconds(0);
            return minTime + time1 + time2 + timeSlide;
        }
    }
}
