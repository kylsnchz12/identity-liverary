namespace liveraryIdentity.Models;

public class HomeViewModel
{
    public IEnumerable<Training> Trainings { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}
