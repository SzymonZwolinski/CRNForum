namespace Platender.Front.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string AddingUserName { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
