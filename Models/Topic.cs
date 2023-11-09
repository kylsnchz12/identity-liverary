namespace liveraryIdentity.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public int TrainingID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}
