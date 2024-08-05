using ConsoleApp.TrackWorks;
using System.Diagnostics;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start F1 Game console project!");
            var sw = new Stopwatch();
            sw.Start();
            // ------------ action ----------------------------------

            var australiaTrack = new Australia();
            var race = new Race();
            race.Start(australiaTrack);

            // ------------ finish action ---------------------------
            sw.Stop();
            Console.WriteLine($"App execuiting {sw.ElapsedMilliseconds} millisecond");
            Console.WriteLine("End F1 Game app!");
        }
    }
}
