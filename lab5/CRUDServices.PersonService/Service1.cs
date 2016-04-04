using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Model;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;

namespace CRUDServices.PersonService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private readonly IPersonRepository _personRepository;

        public Service1()
        {
            this._personRepository = new PersonRepository();
        }
        public int AddPerson(Person person)
        {
            return this._personRepository.Add(person);
        }

        public bool DeletePerson(int id)
        {
            return this._personRepository.Delete(id);
        }

        public List<Person> GetAllPersons()
        {
            return this._personRepository.GetAll();
        }

        public Person GetPerson(int id)
        {
            return this._personRepository.Get(id);
        }

        public Person UpdatePerson(Person person)
        {
            return this._personRepository.Update(person);
        }
    }

}
