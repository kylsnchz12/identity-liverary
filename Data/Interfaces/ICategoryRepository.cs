namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface ICategoryRepository
{
    IEnumerable<Category> Categories { get; }

}