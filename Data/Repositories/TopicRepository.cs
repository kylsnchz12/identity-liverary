using liveraryIdentity.Models;
using liveraryIdentity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace liveraryIdentity.Data.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _context;
        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Topic> GetAllTopics()
        {
            return _context.Topics.ToList();
        }
        
        public Topic GetTopicById(int topicTrainingId) => _context.Topics.FirstOrDefault(p => p.TrainingID == topicTrainingId);
    }
}