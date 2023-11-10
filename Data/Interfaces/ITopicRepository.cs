namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface ITopicRepository
{
    IEnumerable<Topic> Topics { get; }

}