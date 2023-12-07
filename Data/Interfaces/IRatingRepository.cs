namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface IRatingRepository
{
    List<Rating> GetRatingByTrainingId(int trainingId);

}