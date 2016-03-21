using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

namespace Space
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:9009/Ship");
            ServiceHost selfHost = new ServiceHost(typeof(BlackHole), address);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "BlackholeServiceEndpoint");
                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smd);
                selfHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
                selfHost.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });

                selfHost.Open();
                Console.WriteLine("Service is running!");
                Console.ReadLine();

                selfHost.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                selfHost.Abort();
            }
        }


    }

    public class Starship
    {
        public string Name { get; set; }
        public Person Captain { get; set; }
        public List<Person> Crew { get; set; }

        public void PresentCrew(Starship starship)
        {
            PrintPerson(starship.Captain);
            foreach (var person in starship.Crew)
            {
                PrintPerson(person);
            }
        }

        public void PrintPerson(Person person)
        {
            Console.WriteLine("Name: {0}, age: {1}", person.Name, person.Age);
        }
    }
}
