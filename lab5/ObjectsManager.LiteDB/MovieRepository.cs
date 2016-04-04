using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Interfaces;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _movieConnection = DBConnections.MovieConnection;


        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var dbObject = InverseMap(movie);

                var repository = db.GetCollection<Movie>("movies");
                if (repository.FindById(movie.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<Movie>("movies");
                return repository.Delete(id);
            }
        }

        public Movie Get(int id)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<Movie>("movies");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<Movie>("movies");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public Movie Update(Movie Movie)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var dbObject = InverseMap(Movie);

                var repository = db.GetCollection<Movie>("movies");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        internal Movie Map(Movie dbMovie)
        {
            if (dbMovie == null)
                return null;
            return new Movie() { Id = dbMovie.Id, Title = dbMovie.Title, ReleaseYear = dbMovie.ReleaseYear };
        }

        internal Movie InverseMap(Movie Movie)
        {
            if (Movie == null)
                return null;
            return new Movie() { Id = Movie.Id, Title = Movie.Title, ReleaseYear = Movie.ReleaseYear };
        }
    }
}
