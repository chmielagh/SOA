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
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _movieConnection = DBConnections.MovieConnection;


        public int Add(Review review)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var dbObject = InverseMap(review);

                var repository = db.GetCollection<Review>("reviews");
                if (repository.FindById(review.Id) != null)
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
                var repository = db.GetCollection<Review>("reviews");
                return repository.Delete(id);
            }
        }

        public Review Get(int id)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<Review>("reviews");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Review> GetAll()
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<Review>("reviews");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public Review Update(Review Review)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var dbObject = InverseMap(Review);

                var repository = db.GetCollection<Review>("reviews");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        internal Review Map(Review dbReview)
        {
            if (dbReview == null)
                return null;
            return new Review() { Id = dbReview.Id, Content = dbReview.Content, Score = dbReview.Score, Author = dbReview.Author, MovieId = dbReview.MovieId };
        }

        internal Review InverseMap(Review review)
        {
            if (review == null)
                return null;
            return new Review() { Id = review.Id, Content = review.Content, Score = review.Score, Author = review.Author, MovieId = review.MovieId };
        }
    }
}
