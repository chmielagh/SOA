using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Model;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;

namespace CRUDServices.ReviewService
{
    public class Service1 : IService1
    {
        private readonly IReviewRepository _reviewRepository;

        public Service1()
        {
            this._reviewRepository = new ReviewRepository();
        }
        public int AddReview(Review review)
        {
            return this._reviewRepository.Add(review);
        }

        public bool DeleteReview(int id)
        {
            return this._reviewRepository.Delete(id);
        }

        public List<Review> GetAllReviews()
        {
            return this._reviewRepository.GetAll();
        }

        public Review GetReview(int id)
        {
            return this._reviewRepository.Get(id);
        }

        public Review UpdateReview(Review review)
        {
            return this._reviewRepository.Update(review);
        }
    }
}
