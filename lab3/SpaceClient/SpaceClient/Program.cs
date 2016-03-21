using System;
using SpaceClient.BlackholeServiceReferences;
using System.Collections.Generic;


namespace SpaceClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            BlackHoleClient client = new BlackHoleClient();
            Starship starship = CreateStarship(5);
            starship = client.PullStarship(starship);
            Console.WriteLine(client.UltimateAnswer());
            Console.ReadLine();
            client.Close();
        }

        static Starship CreateStarship(int size)
        {
            Person captain = new Person() { Name = "captain", Age = new Random().Next(30,45) };
            List<Person> crew = new List<Person>();
            for (int i = 0; i < size; i++)
            {
                crew.Add(new Person() { Name = "member" + i, Age = new Random().Next(20,45)});
            }
            
            return new Starship() { Name = "ship", Captain = captain, Crew = crew.ToArray() };
        }

    }
}
