using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.ServiceReference1;
using ConsoleApplication1.ServiceReference2;

namespace ConsoleApplication1
{
    class Program
    {
        static List<Starship> _starships = new List<Starship>();
        static bool _anySystem = true;
        static int _gold = 1000;
        static int _imperiumMoneyAskCount = 4;


        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client1 = new ServiceReference1.Service1Client();
            ServiceReference2.Service1Client client2 = new ServiceReference2.Service1Client();
            client1.InitializeGame();

            ConsoleKeyInfo key;
            do
            {
                key = Menu();
                Console.WriteLine("\n\n");
                switch (key.Key.ToString())
                {
                    case "A":
                        askForMoney(client2);
                        break;
                    case "B":
                        buyShip(client1);
                        break;
                    case "C":
                        sendShip(client1);
                        break;
                    default:
                        Console.WriteLine("Błędny klawisz\n\n");
                        break;
                }

            } while (key.Key != ConsoleKey.Escape);
            FinalizeGame();
            Console.ReadKey();
        }

        private static void FinalizeGame()
        {
            if (_anySystem == true)
                Console.WriteLine("Wygrana");
            else
                Console.WriteLine("Przegrana");
        }

        private static void buyShip(ServiceReference1.Service1Client client)
        {
            Console.WriteLine("Aktualne złoto: {0}. Wpisz za ile chcesz kupić statek", _gold);
            int money = Convert.ToInt32(Console.ReadLine());
            if(money <= _gold)
            {
                _starships.Add(client.GetStarship(money));
                _gold = _gold - money;
            } else
            {
                Console.WriteLine("Błędna kwota");
            }
        }

        private static void sendShip(ServiceReference1.Service1Client client)
        {
            SpaceSystem system = client.GetSystem();
            if (system != null) {
                Console.WriteLine("System {0}, odległość {1}.", system.Name, system.BaseDistance);
                Console.WriteLine("Statków gotowych do podróży: {0}", _starships.Count);
                Console.WriteLine("Wybierz statek wpisując jego numer (albo wyjdź wpisując literę e):");
                int i = 1;
                foreach (Starship ship in _starships)
                {
                    Console.Write("\n{0}. ",i);
                    PrintStarship(ship);
                    i++;
                }
                string option = Console.ReadLine();
                if (!option.Equals("e")){
                    int number = Convert.ToInt32(option);
                    Starship ship = _starships.ElementAt(number-1);
                    _starships.RemoveAt(number-1);
                    ship = client.SendStarship(ship,system.Name);
                    if (ship.Gold > 0)
                    {
                        _gold += ship.Gold;
                        ship.Gold = 0;
                    }
                    if(ship.Crew.Count() > 0)
                    {
                        _starships.Add(ship);
                    }
                }

            } else
            {
                _anySystem = false;
                Console.WriteLine("Brak systemów");
            }
        }

        private static void PrintStarship(Starship ship)
        {
            Console.Write(ship.ShipPower);
            foreach (Person member in ship.Crew)
                    Console.Write(", {0},{1},{2}", member.Name, member.Nick, member.Age);
            Console.Write("\n");
        }

        private static void askForMoney(ServiceReference2.Service1Client client)
        {
            if (_imperiumMoneyAskCount > 0)
            {
                _gold += client.GetMoneyFromImperium();
                _imperiumMoneyAskCount--;
            }
            else
                Console.WriteLine("Wyczerpales limit");
        }

        private static ConsoleKeyInfo Menu()
        {
            Console.WriteLine("Złoto: "+ _gold);
            Console.WriteLine("Prośby o złoto: " + _imperiumMoneyAskCount);
            Console.WriteLine("a ) Popros imperium o zloto");
            Console.WriteLine("b ) Kup statek za złoto");
            Console.WriteLine("c ) Wyślij statek do systemu");
            Console.WriteLine("ESC ) Zakończ grę");
            return Console.ReadKey();
        }
    }
}
