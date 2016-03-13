using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z1
{
    public class Animal
    {
        public string Name { get; set; }
        public float Weigth { get; set; }
        public bool HaveFur { get; set; }

        public Animal() { }
        public Animal(string Name, float Weigth, bool HaveFur)
        {
            this.Name = Name;
            this.Weigth = Weigth;
            this.HaveFur = HaveFur;
        }
        public virtual string Sound()
        {
            return "Default sound.";
        }

        public virtual string Trick()
        {
            return "Default trick.";
        }

        public virtual int CountLegs()
        {
            return 4;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class Circus : ICircus
    {
        public List<Animal> Animals { get; set; }
        public string Name { get; set; }

        public Circus()
        {
            Name = "sejm";
            Animals = new List<Animal>();
            Animals.Add(new Cat("Adam", 5, true, "Black"));
            Animals.Add(new Elephant("Jarek", 500, false));
            Animals.Add(new Ant("Beata", 1, false));
            Animals.Add(new Pony("Przemek", 40, true, true));
            Animals.Add(new Pony("Janusz", 55, true, true));
            Animals.Add(new Giraffe("Roman", 150, true));
        }

        public string AnimalsIntroduction()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Animal TempAnimal in Animals)
            {
                sb.Append(TempAnimal.Sound() + "\n");
            }
            return sb.ToString();
        }

        public int Patter(int HowMuch)
        {
            int sum = 0;
            foreach (Animal tempAnimal in Animals)
            {
                sum += (tempAnimal.CountLegs() * HowMuch);
            }
            return sum;
        }

        public string Show()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Animal TempAnimal in Animals)
            {
                sb.Append(TempAnimal.Trick() + "\n");
            }
            return sb.ToString();
        }

        public string Names()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Animal temp in Animals)
            {
                sb.Append(temp.Name + "\n");
            }
            return sb.ToString();
        }
    }

    class Zoo : IZoo
    {
        public List<Animal> Animals{get; set;}
        public string Name { get; set; }

        public Zoo()
        {
            this.Name = "Zo";
            Animals = new List<Animal>();
            Animals.Add(new Cat("Adam", 5, true, "Black"));
            Animals.Add(new Elephant("Jarek", 500, false));
            Animals.Add(new Ant("Beata", 1, false));
            Animals.Add(new Pony("Przemek", 40, true, true));
            Animals.Add(new Pony("Janusz", 55, true, true));
            Animals.Add(new Giraffe("Roman", 150, true));
        }

        public string Sounds()
        {
            return Animals.Select(anim => anim.Sound()).Aggregate((prev, next) => prev + next);
        }
    }


    class Cat : Animal
    {
        public string Color { get; set; }

        public Cat() { }

        public Cat(string Name, float Weigth, bool HaveFur, string Color) : base(Name, Weigth, HaveFur)
        {
            this.Color = Color;
        }

        override public string Sound()
        {
            return "Meaow.";
        }

        override public string Trick()
        {
            return "Licking a butter.";
        }

        override public int CountLegs()
        {
            return 4;
        }

    }

    class Pony : Animal
    {
        public bool IsMagic { get; set; }

        public Pony(string Name, float Weigth, bool HaveFur, bool IsMagic) : base(Name, Weigth, HaveFur)
        {
            this.IsMagic = IsMagic;
        }

        override public string Sound()
        {
            return "Pony sound.";
        }

        override public string Trick()
        {
            return "Flying.";
        }

        override public int CountLegs()
        {
            return 4;
        }
    }

    class Ant : Animal
    {
        bool IsQueen;

        public Ant(string Name, float Weigth, bool HaveFur, bool IsQueen) : base(Name, Weigth, HaveFur)
        {
            this.IsQueen = IsQueen;
        }

        public Ant(string Name, float Weigth, bool HaveFur) : base(Name, Weigth, HaveFur)
        {
        }

        override public string Sound()
        {
            return "Silence.";
        }

        override public string Trick()
        {
            return "Bitting.";
        }

        override public int CountLegs()
        {
            return 6;
        }
    }

    class Elephant : Animal
    {
        public Elephant(string Name, float Weigth, bool HaveFur) : base(Name, Weigth, HaveFur)
        {
        }

        override public string Sound()
        {
            return "Trrrr.";
        }

        override public string Trick()
        {
            return "Smashing.";
        }

        override public int CountLegs()
        {
            return 4;
        }
    }

    class Giraffe : Animal
    {
        public Giraffe(string Name, float Weigth, bool HaveFur) : base(Name, Weigth, HaveFur)
        {
        }

        override public string Sound()
        {
            return "Giraffe sound.";
        }

        override public string Trick()
        {
            return "Playing basketball.";
        }

        override public int CountLegs()
        {
            return 4;
        }
    }

    interface ICircus
    {
        string AnimalsIntroduction();
        string Show();
        int Patter(int HowMuch); //Tupanie
    }

    interface IZoo
    {
        string Sounds();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circus Cyrk = new Circus();
            Zoo Zoo = new Zoo();
            System.ConsoleKeyInfo k;
            do
            {
                k = Menu();
                Console.WriteLine();
                switch (k.Key.ToString())
                {
                    case "A":
                        Console.WriteLine(Cyrk.AnimalsIntroduction());
                        break;
                    case "B":
                        Console.WriteLine(Cyrk.Show());
                        break;
                    case "C":
                        Console.WriteLine(Zoo.Sounds());
                        break;
                    case "D":
                        Console.WriteLine(Zoo.Animals.Where(x => x.HaveFur == true).FirstOrDefault());
                        break;
                    case "E":
                        Console.WriteLine(Cyrk.Names());
                        break;
                    default:
                        Console.WriteLine("Klawisz nieprzypisany");
                        break;
                }
            } while (k.Key != ConsoleKey.Escape) ;
        }

        private static System.ConsoleKeyInfo Menu()
        {
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("a ) Prezentacja Zwierząt w cyrku;");
            Console.WriteLine("b ) Obejrzenie programu cyrku");
            Console.WriteLine("c ) Posłuchanie dźwięków Zoo ");
            Console.WriteLine("d ) Wyświetla imię pierwszego znalezionego futrzaka w Zoo");
            Console.WriteLine("e ) wyświetla wszystkie imiona zwierząt w Cyrku");
            return Console.ReadKey();
        }
    }
}
