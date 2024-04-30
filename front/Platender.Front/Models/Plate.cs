namespace Platender.Front.Models
{
    public class Plate
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int LikeAmount { get; set; }
        public int DislikeAmount { get; set; }
        public List<Comment>? Comments { get; set; }
        public string Culture { get; set; }
        public string UserReaction { get; set; }
    }
}
