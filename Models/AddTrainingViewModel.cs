namespace liveraryIdentity.Models
{
    public class AddTrainingViewModel
    {
        public string Title { get; set; }

        public int CategoryID { get; set; }

        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Thumbnail { get; set; }
    }
}