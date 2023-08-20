namespace Platender.Front.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string AddingUserName { get; set; } // W przyszłosic powinien być to idk usera, na ten moment nie robie usera 
        public int Sequence { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}
