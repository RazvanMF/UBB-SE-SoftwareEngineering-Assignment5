using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Business.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        }

        public int AddReview(Review review)
        {
            return reviewRepository.AddReview(review);
        }

        public bool DeleteReview(int id)
        {
            return reviewRepository.DeleteReview(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return reviewRepository.GetAllReviews();
        }

        public Review? GetReview(int id)
        {
            return reviewRepository.GetReview(id);
        }

        public IEnumerable<Review> GetReviewsForProduct(int productId)
        {
            return reviewRepository.GetReviewsForProduct(productId);
        }

        public IEnumerable<Review> GetReviewsFromUser(int userId)
        {
            return reviewRepository.GetReviewsFromUser(userId);
        }

        public bool UpdateReview(int id, Review review)
        {
            return reviewRepository.UpdateReview(id, review);
        }
    }
}
