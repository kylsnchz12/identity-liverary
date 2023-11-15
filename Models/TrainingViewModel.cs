namespace liveraryIdentity.Models;

public class TrainingViewModel
{
    public Training Training { get; set; }
    public IEnumerable<Category> Categories { get; set; }

    public List<Topic> Topics { get; set; }
    
}
