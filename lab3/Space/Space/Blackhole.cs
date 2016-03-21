using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class BlackHole : IBlackHole
    {
        public BlackHole() { }
        public Starship PullStarship(Starship ship)
        {
            Console.WriteLine("Before pull:");
            ship.PresentCrew(ship);
            if (ship.Captain.Age <= 40)
            {
                foreach (var person in ship.Crew)
                {
                    person.Age += 20;
                }
            }
            Console.WriteLine("After pull:");
            ship.PresentCrew(ship);
            return ship;
        }

        public string UltimateAnswer()
        {
            return 42.ToString();
        }
    }
}
