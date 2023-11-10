namespace liveraryIdentity.Models;

public class Training
{
    public int TrainingId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public string TrainingDescription { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
    
    public List<Topic>? Topics { get; set; }
}
