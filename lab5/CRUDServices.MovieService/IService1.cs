using ObjectsManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRUDServices.MovieService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int AddMovie(Movie movies);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        Movie UpdateMovie(Movie movies);

        [OperationContract]
        bool DeleteMovie(int id);
    }
}
