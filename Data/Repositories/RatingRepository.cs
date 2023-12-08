using liveraryIdentity.Models;
using liveraryIdentity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace liveraryIdentity.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Rating> GetRatingByTrainingId(int trainingId)
        {
            return _context.Ratings.Where(r => r.TrainingID == trainingId).ToList();
        }

    }
}