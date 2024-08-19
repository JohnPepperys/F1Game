using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClass
{
    public static class GameCommon
    {
        public static int[] ResultPoints = new int[] { 25, 18, 15, 12, 10,  8, 6, 4, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        /// <summary>
        /// создаем гоночные команды
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<F1Team> InitF1Teams()
        {
            List<F1Team> teams = new List<F1Team>() {
                new F1Team(1, "Red Bull Racing", "Oracle Red Bull Racing", 1997, 0, "Honda RBPT"),
                new F1Team(2, "Ferrari", "Scuderia Ferrari", 1950, 0, "Ferrari"),
                new F1Team(3, "McLaren", "McLaren F1 Team", 1966, 0, "Mercedes"),
                new F1Team(4, "Mercedes", "Mercedes-AMG Petronas F1 Team", 1970, 0, "Mercedes"),
                
                new F1Team(5, "Aston Martin", "Aston Martin Aramco F1 Team", 2018, 0, "Mercedes"),
                new F1Team(6, "RB", "Visa Cash App RB Formula One Team", 1985, 0, "Honda RBPT"),
                new F1Team(7, "Haas", "MoneyGram Haas F1 Team", 2016, 0, "Ferrari"),
                new F1Team(8, "Alpine", "BWT Alpine F1 Team", 1986, 0, "Renault"),
                
                new F1Team(9, "Williams", "Williams Racing", 1978, 0, "Mercedes"),
                new F1Team(10, "Kick Sauber", "Stake F1 Team Kick Sauber", 1993, 0, "Ferrari")
            }; 
            return teams;
        }

        /// <summary>
        /// создаем пилотов
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public static IEnumerable<F1Pilot> InitPilots(IEnumerable<F1Team> teams) {            
            return new List<F1Pilot>() { 
                new F1Pilot("Max,Verstappen", 2024-1997, teams.First(x => x.Id == 1), 1, 194, "Netherlands"),
                new F1Pilot("Charles,Leclerc", 2024-1997, teams.First(x => x.Id == 2), 16, 134, "Monaco"),
                new F1Pilot("Lando,Norris", 2024 - 1999, teams.First(x => x.Id == 3), 4, 113, "United Kingdom"),
                new F1Pilot("Carlos,Sainz", 2024 - 1994, teams.First(x => x.Id == 2), 55, 193, "Spain"),
                
                new F1Pilot("Sergio,Perez", 2024 - 1990, teams.First(x => x.Id == 1), 11, 267, "Mexico"),
                new F1Pilot("Oscar,Piastri", 2024 - 2001, teams.First(x => x.Id == 3), 81, 31, "Australia"),
                new F1Pilot("George,Russell", 2024 - 1998, teams.First(x => x.Id == 4), 63, 113, "United Kingdom"),               
                new F1Pilot("Lewis,Hamilton", 2024 - 1985, teams.First(x => x.Id == 4), 44, 341, "United Kingdom"),
                
                new F1Pilot("Fernando,Alonso", 2024-1981, teams.First(x => x.Id == 5), 14, 389, "Spain"),
                new F1Pilot("Yuki,Tsunoda", 2024 - 2000, teams.First(x => x.Id == 6), 22, 75, "Japan"),
                new F1Pilot("Lance,Stroll", 2024-1998, teams.First(x => x.Id == 5), 18, 152, "Canada"),
                new F1Pilot("Daniel,Ricciardo", 2024-1989, teams.First(x => x.Id == 6), 3, 248, "Australia"),
                
                new F1Pilot("Nico,Hulkenberg", 2024-1987, teams.First(x => x.Id == 7), 27, 215, "Germany"),
                new F1Pilot("Pierre,Gasly", 2024-1996, teams.First(x => x.Id == 8), 10, 139, "France"),
                new F1Pilot("Alexander,Albon", 2024-1990, teams.First(x => x.Id == 9), 23, 90, "Thailand"),
                new F1Pilot("Esteban,Ocon", 2024-1996, teams.First(x => x.Id == 8), 31, 142, "France"),
                
                new F1Pilot("Kevin,Magnussen", 2024-1992, teams.First(x => x.Id == 7), 20, 173, "Denmark"),
                new F1Pilot("Guanyu,Zhou", 2024-1999, teams.First(x => x.Id == 10), 24, 53, "China"),
                new F1Pilot("Valtteri,Bottas", 2024-1989, teams.First(x => x.Id == 10), 77, 231, "Finland"),
                new F1Pilot("Logan,Sargeant", 2024-2000, teams.First(x => x.Id == 9), 2, 30, "United States")
            };
        }

        /// <summary>
        ///  создаем трек
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<F1Track> InitTracks() {
            return new List<F1Track>() { 
                new F1Track(1, "Bahrain", "Bahrain", 308238, 57, new TimeSpan(0, 0, 1, 29, 100), new TimeSpan(0, 0, 1, 32, 208), false),
                new F1Track(2, "Jeddah", "Saudi Arabian", 308450, 50, new TimeSpan(0, 0, 1, 27, 300), new TimeSpan(0, 0, 1, 31, 400), false),
                new F1Track(3, "Melbourne Park", "Australia", 306124, 58, new TimeSpan(0, 0, 1, 15, 800), new TimeSpan(0, 0, 1, 19, 700), false),
                new F1Track(4, "Suzuka", "Japan", 307471, 53, new TimeSpan(0, 0, 1, 28, 50), new TimeSpan(0, 0, 1, 33, 500), false),

                new F1Track(5, "Shanghai", "China", 305066, 56, new TimeSpan(0, 0, 1, 33, 550), new TimeSpan(0, 0, 1, 37, 700), false),
                new F1Track(6, "Miami", "USA", 308326, 57, new TimeSpan(0, 0, 1, 27, 150), new TimeSpan(0, 0, 1, 30, 540), false),
                new F1Track(7, "Emilia-Romagna", "Italy", 309049, 63, new TimeSpan(0, 0, 1, 14, 680), new TimeSpan(0, 0, 1, 18, 490), false),
                new F1Track(8, "Monaco", "Monaco", 260286, 78, new TimeSpan(0, 0, 1, 10, 250), new TimeSpan(0, 0, 1, 14, 100), false)
            };
        }
    }
}
