using ObjectsManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Model;
using LiteDB;

namespace ObjectsManager.LiteDB
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _personConnection = DBConnections.PersonConnection;


        public int Add(Person person)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var dbObject = InverseMap(person);

                var repository = db.GetCollection<Person>("persons");
                if (repository.FindById(person.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<Person>("persons");
                return repository.Delete(id);
            }
        }

        public Person Get(int id)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<Person>("persons");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Person> GetAll()
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<Person>("persons");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public Person Update(Person person)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var dbObject = InverseMap(person);

                var repository = db.GetCollection<Person>("persons");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        internal Person Map(Person dbPerson)
        {
            if (dbPerson == null)
                return null;
            return new Person() { Id = dbPerson.Id, Name = dbPerson.Name, Surname = dbPerson.Surname };
        }

        internal Person InverseMap(Person person)
        {
            if (person == null)
                return null;
            return new Person() { Id = person.Id, Name = person.Name, Surname = person.Surname };
        }

    }
}
