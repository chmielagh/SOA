using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassLibrary1;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private List<SpaceSystem> _systems;

        public Starship GetStarship(int money)
        {
            Starship starship = getRandomStarship();
            if (money > 1000 && money <= 3000)
                starship.ShipPower = new Random().Next(10, 25);
            else if (money > 3001 && money <= 10000)
                starship.ShipPower = new Random().Next(20, 35);
            else if (money > 10000)
                starship.ShipPower = new Random().Next(35, 60);
            return starship;
        }


        public SpaceSystem GetSystem()
        {
            return _systems.First<SpaceSystem>();
        }

        public void InitializeGame()
        {
            _systems = this.getRandomSpaceSystems(4);
        }

        public Starship SendStarship(Starship starship, string systemName)
        {
            SpaceSystem system = null;
            foreach(SpaceSystem ss in _systems)
            {
                if (ss.Name.Equals(systemName)) system = ss;
            }
            if (system != null)
            {
                if(starship.ShipPower <= 20)
                    foreach(Person member in starship.Crew)
                        member.Age += (2 * system.BaseDistance) / 12;
                else if(starship.ShipPower <= 30)
                    foreach (Person member in starship.Crew)
                        member.Age += (2 * system.BaseDistance) / 6;
                else
                    foreach (Person member in starship.Crew)
                        member.Age += (2 * system.BaseDistance) / 4;
                foreach (Person member in starship.Crew)
                    if (member.Age > 90) starship.Crew.Remove(member);
                if (system.isEnoughPower(starship))
                {
                    starship.Gold += system.getLoot();
                    _systems.Remove(system);
                }
            } else
            {
                starship.Crew.Clear();         
            }
            return starship;
        }

        private List<SpaceSystem> getRandomSpaceSystems(int number)
        {
            List<SpaceSystem> SpaceSystems = new List<SpaceSystem>();
            for(int i=0; i< number; i++)
            {
                string Name = "SS" + i;
                int MinShipPower = new Random().Next(10, 40);
                int BaseDistance = new Random().Next(20, 120);
                int Gold = new Random().Next(3000, 7000);
                SpaceSystem tempSS = new SpaceSystem(Name, MinShipPower, BaseDistance, Gold);
                SpaceSystems.Add(tempSS);
            }
            return SpaceSystems;
        }


        private Starship getRandomStarship()
        {
            return new Starship()
            {
                Crew = new List<Person>(new Person[]{new Person("Adam",20), new Person("Maciek",20), new Person("Jan", 20), new Person("Eryk", 20) }),
                Gold = 0,
                ShipPower = 10000
            };
        }
    }
}
