namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface IResourceRepository
{
    List<Resource> GetAllResources();
    List<Resource> GetAllResourcesByTopicId(int topicId);
}