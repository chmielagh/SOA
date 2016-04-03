using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [DataContract]
    public class SpaceSystem
    {
        public SpaceSystem(string name, int msp, int bd, int gold)
        {
            this.Name = name;
            this.MinShipPower = msp;
            this.BaseDistance = bd;
            this.Gold = gold;
        }


        [DataMember]
        public string Name { get; set; }
        private int MinShipPower { get; set; }
        [DataMember]
        public int BaseDistance { get; set; }
        private int Gold { get; set; }

        public bool isEnoughPower(Starship starship)
        {
            return (starship.ShipPower >= this.MinShipPower);
        }

        public int getLoot()
        {
            int loot = this.Gold;
            this.Gold = 0;
            return loot;
        }
    }

    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> Crew { get; set; }
        [DataMember]
        public int Gold { get; set; }
        [DataMember]
        public int ShipPower { get; set; }
    }

    [DataContract]
    public class Person
    {
        public Person() { }
        public Person(string Name, float Age)
        {
            this.Name = Name;
            this.Nick = Name + "zord";
            this.Age = Age;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Nick { get; set; }
        [DataMember]
        public float Age { get; set; }
    }
}
