using liveraryIdentity.Models;
using liveraryIdentity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace liveraryIdentity.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories.ToList();

        public Category GetCategoryById(int categoryId) => _context.Categories.FirstOrDefault(p => p.ID == categoryId);
    }
}