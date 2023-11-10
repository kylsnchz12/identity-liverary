namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface ITrainingRepository
{
    IEnumerable<Training> Trainings { get; }
    Training? GetTrainingById(int trainingId);
}