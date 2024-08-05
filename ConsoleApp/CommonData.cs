namespace ConsoleApp
{
    internal static class CommonData
    {
        public static readonly List<(string, string, int)> drivers = new List<(string, string, int)>() {
           ("Ferrari",              "C.Lecleir",    16),
           ("Ferrari",              "C.Sainz",      55),
           ("Aston Martin",         "F.Alonso",     14),
           ("Aston Martin",         "L.Stroll",     18),
           ("McLaren",              "L.Norris",     4),
           ("Mclaren",              "O.Piastry",    81),
           ("Mercedes",             "L.Hamilton",   44),
           ("Mercedes",             "G.Russel",     63),
           ("Red Bull",             "M.Verstappen", 1),
           ("Red Bull",             "S.Perez",      11),
           ("Williams",             "A.Albon",      23),
           ("Williams",             "L.Sargeant",   2),
           ("Alpine",               "E.Ocon",       31),
           ("Alpine",               "P.Gasly",      10),
           ("Racing Bulls",         "Y.Tsunoda",    22),
           ("Racing Bulls",         "D.Ricciardo",  3),
           ("Haas",                 "K.Magnussen",  20),
           ("Haas",                 "N.Hulkenberg", 27),
           ("Kick Sauber",          "V.Bottas",     77),
           ("Kick Sauber",          "G.Zhou",       24),
        };

        public static readonly int[] points = { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }
}
