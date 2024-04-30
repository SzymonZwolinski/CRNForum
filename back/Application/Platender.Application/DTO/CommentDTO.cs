using Platender.Core.Enums;

namespace Platender.Application.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string AddingUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikeAmount { get; set; }
        public int DislikeAmount { get; set; }
        public string? UserReaction { get; set; } 

        public CommentDto(
            Guid id,
            string description,
            byte[] image,
            string addingUserName,
            DateTime createdAt,
            int likeAmount,
            int dislikeAmount,
            LikeType? userReaction)
        {
            Id = id;
            Description = description;
            Image = image;
            AddingUserName = addingUserName;
            CreatedAt = createdAt;
            LikeAmount = likeAmount;
            DislikeAmount = dislikeAmount;
            UserReaction = userReaction.HasValue ? userReaction.ToString() : null;
        }
    }
}
