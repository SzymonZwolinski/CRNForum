using Platender.Front.Models.Enums;

namespace Platender.Front.DTO
{
    public class PlateDto
    {
        public string Numbers { get; set; }
        public string CultureCode { get; set; }

        public PlateDto(string numbers, string cultureCode)
        {
            Numbers = numbers;
            CultureCode = cultureCode;
        }
    }
}
