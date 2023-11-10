namespace liveraryIdentity.Data.Mocks;
using liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;
public class MockTrainingRepository:ITrainingRepository
{
    private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
    public IEnumerable<Training> Trainings { 
        get 
        {
            return new List<Training>
            {
                new Training {
                    Title = "Training 1",
                    Author = "Four",
                    TrainingDescription = "Long Desc ni",
                    ImageUrl = "/images/training_bg.png",
                },
                new Training {
                    Title = "Training 2",
                    Author = "Tris",
                    TrainingDescription = "Long Desc ni",
                    ImageUrl = "/images/training_bg.png",
                }
            };
        }
    }


    public Training GetTrainingById(int trainingId)
    {
        throw new NotImplementedException();
    }
}