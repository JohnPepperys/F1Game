using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClass
{
    public class F1Pilot
    {
        /// <summary>
        /// full pilot name in format <Name,Surname>, for example: "Charles,Leclear"
        /// </summary>
        string _name, _surname;
        public string Surname { get { return _surname;} }       // return Leclear
        public string Name { get { return _name;} }         // return Charles
        public string ShortName { get { return _surname.Substring(0, 3); } }   // return Lec
        public string FullName { get { return $"{_name} {_surname}"; } }

        string _country;
        public string Country { get { return _country;} }   

        /// <summary>
        /// pilots ages
        /// </summary>
        int _age;
        public int Age { get { return _age; } }

        /// <summary>
        ///  pilots team
        /// </summary>
        F1Team _team;
        public F1Team Team { get { return _team; } }

        /// <summary>
        ///  pilot's number
        /// </summary>
        int _number;
        public int Number { get { return _number; } }

        int _races;
        public int Races { get { return _races; } }

        public F1Pilot(string name, int age, F1Team team, int num, int races, string country) {
            if (String.IsNullOrEmpty(name) || !name.Contains(',') || String.IsNullOrEmpty(country))
                throw new ArgumentException("incorrect name parameter");
            if (age < 18 || age > 50)
                throw new ArgumentException("incorrect age parameter");
            if (team == null)
                throw new ArgumentException("team is null");
            if (num < 0 || num > 99)
                throw new ArgumentException("incorrect num parameter");
            if (races < 0)
                throw new ArgumentException("incorrect races parameter");
            
            var tempname = name.Split(',');
            _name = tempname[0];
            _surname = tempname[1];
            _age = age;
            _number = num;
            _races = races;
            _team = team;
            _country = country;
        }
    }
}
