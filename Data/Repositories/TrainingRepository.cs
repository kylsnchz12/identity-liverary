using liveraryIdentity.Models;
using liveraryIdentity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace liveraryIdentity.Data.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _context;
        public TrainingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Training> Trainings => _context.Trainings.ToList();

        public Training GetTrainingById(int trainingId) => _context.Trainings.FirstOrDefault(p => p.ID == trainingId);

        public IEnumerable<Training> GetTrainingsByTitle(string searchTerm) => _context.Trainings.Where(t => t.Title.Contains(searchTerm)).ToList();
    }
}