using Platender.Front.Models.Enums;

namespace Platender.Front.DTO
{
    public class PlateDto
    {
        public string Numbers;
        public CultureCode? CultureCode;

        public PlateDto(string numbers, CultureCode? cultureCode)
        {
            Numbers = numbers;
            CultureCode = cultureCode;
        }
    }
}
