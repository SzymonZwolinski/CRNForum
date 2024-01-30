﻿namespace Platender.Application.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string AddingUserName { get; set; } 
        public int Sequence { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }

        public CommentDto(
            Guid id,
            string content,
            string addingUserName,
            int sequence,
            int likeCount,
            int dislikeCount)
        {
            Id = id;
            Content = content;
            AddingUserName = addingUserName;
            Sequence = sequence;
            LikeCount = likeCount;
            DislikeCount = dislikeCount;
        }
    }
}
