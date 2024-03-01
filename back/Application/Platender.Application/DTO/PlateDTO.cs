
namespace Platender.Application.DTO
{
    public class PlateDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Culture { get; set; }

        public PlateDto(
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
