
using ConsoleApp.TrackWorks;

namespace ConsoleApp
{
    internal class Race
    {
        int _lap_in_race = 60;
        int _car_in_race = 20;
        List<RaceCar> _raceCar = new List<RaceCar>();

        public void Start(ITrackTimes track) {
            // load race parameters
            _lap_in_race = track.Laps;
            Console.WriteLine();
            // prepare for race
            for (var carind = 0; carind < _car_in_race; carind++)
            {
                _raceCar.Add(new RaceCar(CommonData.drivers[carind].Item1, CommonData.drivers[carind].Item2, CommonData.drivers[carind].Item3));      // make a car
                Console.WriteLine($"Car #{_raceCar.Last().CarNumber} {_raceCar.Last().Team} with driver {_raceCar.Last().Pilot} ready for race!");
            }

            Console.WriteLine();
            // racing
            for (var lapNum = 0; lapNum < _lap_in_race; lapNum++)
            {
                for (var carind = 0; carind < _car_in_race; carind++)
                {
                    if (_raceCar[carind].InRace)
                        if (_raceCar[carind].RunOneLap(track) == true)
                            Console.WriteLine($"Car {_raceCar[carind].Team}\twith driver {_raceCar[carind].Pilot}\tfinished {lapNum + 1} lap with time {_raceCar[carind].GetLastLapTime().ToString("mm':'ss'.'fff")} ms.");
                        else
                            Console.WriteLine($"Car {_raceCar[carind].Team}\twith driver {_raceCar[carind].Pilot} CRASHED.");
                }
            }

            // race result
            Console.WriteLine();
            Console.WriteLine("\t\t\t\tRace results: {0} laps", _lap_in_race);
            var successCar = _raceCar.Where(x => x.InRace).OrderBy(x => x.TotalTime);
            var failCar = _raceCar.Where(x => !x.InRace).OrderBy(x => x.CrashLap);
            int pos = 1;
            foreach (var car in successCar) {
                switch (pos)
                {
                    case 1:
                        Console.WriteLine("\tWinner!!!");
                        Console.WriteLine($"\t1st. #{car.CarNumber}\t{car.Pilot}\t{car.Team}\ttotal time: {car.TotalTime}\t\t+{CommonData.points[pos-1]} points");
                        pos++;
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine($"2nd. #{car.CarNumber}\t{car.Pilot}\t{car.Team}\ttotal time: {car.TotalTime}\t\t+{CommonData.points[pos - 1]} points");
                        pos++;
                        break;

                    case 3:
                        Console.WriteLine($"3rd. #{car.CarNumber}\t{car.Pilot}\t{car.Team}\ttotal time: {car.TotalTime}\t\t+{CommonData.points[pos - 1]} points");
                        pos++;
                        break;

                    default:
                        Console.WriteLine($"{pos++}. #{car.CarNumber}\t{car.Pilot}\t{car.Team}\ttotal time: {car.TotalTime}\t\t+{CommonData.points[pos - 2]} points");
                        break;
                }



            }
            foreach (var car in failCar)
                Console.WriteLine($"Position {pos++}! Car #{car.CarNumber} - DNF - crash on {car.CrashLap} lap");

        }
    }
}
