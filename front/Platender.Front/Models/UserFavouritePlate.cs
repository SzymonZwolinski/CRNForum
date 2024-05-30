namespace Platender.Front.Models
{
    public class UserFavouritePlate
    {
        public Guid PlateId { get; private set; }

        public UserFavouritePlate(Guid plateId)
        {
            PlateId = plateId;
        }
    }
}
