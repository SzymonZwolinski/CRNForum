namespace Platender.Application.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string AddingUserName { get; set; }
        public DateTime CreatedAt { get; set; }

        public CommentDto(
            Guid id,
            string description,
            byte[] image,
            string addingUserName,
            DateTime createdAt)
        {
            Id = id;
            Description = description;
            Image = image;
            AddingUserName = addingUserName;
            CreatedAt = createdAt;
        }
    }
}
