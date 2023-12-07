namespace liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;

public interface IRatingRepository
{
    Rating? GetRatingByTrainingId(int trainingId);

}