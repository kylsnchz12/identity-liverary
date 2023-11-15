namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface ITopicRepository
{
    IEnumerable<Topic> Topics { get; }

    List<Topic> GetAllTopics();

    Topic? GetTopicById(int topicTrainingId);

}