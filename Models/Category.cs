namespace liveraryIdentity.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Thumbnail { get; set; }

        public ICollection<Training>? Trainings { get; set; }
    }
}
