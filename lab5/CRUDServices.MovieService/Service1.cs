using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;
using ObjectsManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRUDServices.MovieService
{
    public class Service1 : IService1
    {    
        private readonly IMovieRepository _movieRepository;

        public Service1()
        {
            this._movieRepository = new MovieRepository();
        }
        public int AddMovie(Movie movie)
        {
            return this._movieRepository.Add(movie);
        }

        public bool DeleteMovie(int id)
        {
            return this._movieRepository.Delete(id);
        }

        public List<Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll();
        }

        public Movie GetMovie(int id)
        {
            return this._movieRepository.Get(id);
        }

        public Movie UpdateMovie(Movie movie)
        {
            return this._movieRepository.Update(movie);
        }
    }
}
