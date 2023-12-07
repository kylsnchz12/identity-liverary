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

        public Rating GetRatingByTrainingId(int trainingId) => _context.Ratings.FirstOrDefault(p => p.TrainingID == trainingId);

    }
}