using Platender.Front.Models.Enums;

namespace Platender.Front.DTO
{
    public class PlateDto
    {
        public string Numbers { get; set; }
        public CultureCode? CultureCode { get; set; }

        public PlateDto(string numbers, CultureCode? cultureCode)
        {
            Numbers = numbers;
            CultureCode = cultureCode;
        }
    }
}
