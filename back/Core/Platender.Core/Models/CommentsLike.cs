using Platender.Core.Enums;
using Platender.Core.Models.Abstract;
using System.Net;

namespace Platender.Core.Models
{
    public class CommentsLike : Like
    {
        public Comment Comment { get; private set; }
        public Guid CommentId { get; private set; }

        public CommentsLike() {}

        public CommentsLike(
            Comment comment,
            IPAddress iPAddress,
            LikeType likeType)
        {
            Comment = comment;
            UserIPAddress = iPAddress;
            LikeType = likeType;
        }
    }
}
