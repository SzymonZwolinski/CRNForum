namespace Platender.Front.Models
{
    public class Plate
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int LikeRatio { get; set; }
        public List<Comment>? Comments { get; set; }
        public string Culture { get; set; }
    }
}
