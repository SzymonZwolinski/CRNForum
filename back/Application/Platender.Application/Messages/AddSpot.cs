namespace Platender.Application.Messages
{
    public class AddSpot
    {
        public Guid PlateId { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public AddSpot(
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
