namespace Platender.Application.DTO
{
    public class FavouritePlateDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Culture { get; set; }

        public FavouritePlateDto(
            Guid id, 
            string number,
            string culture)
        {
            Id = id;
            Number = number;
            Culture = culture;
        }
    }
}
