namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface ICategoryRepository
{
    IEnumerable<Category> Categories { get; }

    Category? GetCategoryById(int trainingId);

    IEnumerable<Category> GetCategoriesByTitle(string searchTerm);
}