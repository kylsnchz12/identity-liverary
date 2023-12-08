namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface ITopicRepository
{

    List<Topic> GetAllTopics();

    Topic? GetTopicById(int topicTrainingId);

}