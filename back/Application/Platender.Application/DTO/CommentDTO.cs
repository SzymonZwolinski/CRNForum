namespace Platender.Application.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public string AddingUserName { get; set; }
        public DateTime CreatedAt { get; set; }

        public CommentDto(
            Guid id,
            string content,
            byte[] image,
            string addingUserName,
            DateTime createdAt)
        {
            Id = id;
            Content = content;
            Image = image;
            AddingUserName = addingUserName;
            CreatedAt = createdAt;
        }
    }
}
