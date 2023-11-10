namespace liveraryIdentity.Models;

public class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }  = string.Empty;

    public string CategoryDescription { get; set; }  = string.Empty;

    public string ImageUrl { get; set; }  = string.Empty;

    public List<Training>? Trainings { get; set; }
    
}
