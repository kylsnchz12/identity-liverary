namespace liveraryIdentity.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public int TrainingID { get; set; }
        public int Rate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

    }
}
