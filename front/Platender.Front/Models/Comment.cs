﻿using Platender.Front.Helpers;

namespace Platender.Front.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string AddingUserName { get; set; }
        public byte[]? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikeAmount { get; set; }
        public int DislikeAmount { get; set; }
        public string? UserReaction { get; set; } 
        public string? Byte64Image => Image == null ? null : CustomConverter.ConvertToBase64String(Image);

        public Comment(){}

        public Comment( 
            string? description, 
            string addingUserName, 
            byte[]? image,
            DateTime createdAt,
            int likeAmount,
            int dislikeAmount)
        {
            Description = description;
            AddingUserName = addingUserName;
            Image = image;
            CreatedAt = createdAt;
            LikeAmount = likeAmount;
            DislikeAmount = dislikeAmount;
        }
    }

}
