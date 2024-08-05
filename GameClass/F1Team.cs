namespace GameClass
{
    public class F1Team
    {
        int _id;
        public int Id { get { return _id; } }

        /// <summary>
        /// name of team
        /// </summary>
        string _name;
        public string Name { get { return _name; } }

        string _longName;
        public string FullName { get { return _longName; } }

        /// <summary>
        /// year of creation of team
        /// </summary>
        int _bornYear;
        public int BornYear { get {  return _bornYear; } }

        /// <summary>
        /// amount of race that team was take part
        /// </summary>
        int _raceAmount;
        public int RaceAmount { get { return _raceAmount; } }

        /// <summary>
        /// who create and get Engine for race cars
        /// </summary>
        string _engineManufacturer;
        public string EngineManufacturer { get { return _engineManufacturer;} }

        public F1Team(int id, string name, string fullname, int year, int race, string man) {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(man) || String.IsNullOrEmpty(fullname))
                throw new ArgumentException("name is null or man is null");
            if (year < 1900 || year > DateTime.Now.Year)
                throw new ArgumentException("incorrect bornyear parameter");
            if (race < 0)
                throw new ArgumentException("incorrect race amount parameters");
            if (id < 0)
                throw new ArgumentException("incorrect ID amount parameters");

            _id = id;
            _name = name;
            _bornYear = year;
            _raceAmount = race;
            _engineManufacturer = man;
            _longName = fullname;
        }
    }
}
