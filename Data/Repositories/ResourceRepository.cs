using liveraryIdentity.Models;
using liveraryIdentity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace liveraryIdentity.Data.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly ApplicationDbContext _context;
        public ResourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Resource> GetAllResources()
        {
            return _context.Resources.ToList();
        }

        public List<Resource> GetAllResourcesByTopicId(int topicId)
        {
            return _context.Resources.Where(r => r.TopicID == topicId).ToList();
        }
        
    }
}