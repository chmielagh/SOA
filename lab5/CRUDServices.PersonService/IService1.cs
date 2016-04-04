using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Model;

namespace CRUDServices.PersonService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int AddPerson(Person person);

        [OperationContract]
        Person GetPerson(int id);

        [OperationContract]
        List<Person> GetAllPersons();

        [OperationContract]
        Person UpdatePerson(Person person);

        [OperationContract]
        bool DeletePerson(int id);
    }
}
