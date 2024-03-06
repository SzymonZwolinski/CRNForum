namespace Platender.Application.Messages
{
    public class AddComment
    {
        public Guid PlateId { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public AddComment(
            Guid plateId,
            byte[] image,
            string description)
        {
            PlateId = plateId;
            Image = image;
            Description = description;  
        }
    }
}
