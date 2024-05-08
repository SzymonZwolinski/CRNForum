namespace Platender.Front.Models
{
    public class SpottImageCarouselItem
    {

        public Guid PlateId { get; set; }
        public string Image { get; set; }
        
         public SpottImageCarouselItem(Guid plateId, string image)
        {
            PlateId = plateId;
            Image = image;
        }
    }
}
