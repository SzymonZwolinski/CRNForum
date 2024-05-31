namespace Platender.Core.Models
{
    public class UserFavouritePlates
    {
        public Guid Id { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; private set; }
        public Plate Plate { get; private set; }
        public Guid PlateId { get; private set; }

        public UserFavouritePlates() {}

        public UserFavouritePlates(Plate plate)
        {
            SetPlate(plate);
        }

        private void SetPlate(Plate plate)
        {
            if(plate is null)
            {
                throw new ArgumentNullException("favourite plate could not be null");
            }

            Plate = plate;
            PlateId = plate.Id;
        }
    }
}
