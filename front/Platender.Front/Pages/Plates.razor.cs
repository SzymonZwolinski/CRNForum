using Microsoft.AspNetCore.Components;
using Platender.Front.Models;
using Platender.Front.Models.Enums;
using Platender.Front.Services;

namespace Platender.Front.Pages
{
    public partial class Plates : ComponentBase
    {
        [Inject]
        private IPlateService _plateService { get; set; }

        public string Numbers;
        public CultureCode? CultureCode;

        private IEnumerable<Plate> _plates = Enumerable.Empty<Plate>();
        private bool IsGetPlatesSend = false;
        private string SentNumbers;
        private CultureCode? SentCultureCode;
        
        private async Task GetPlates()
        {
            _plates = await _plateService.GetPlatesByNumbersAsync(Numbers, CultureCode);

            IsGetPlatesSend = true;
            SentNumbers = Numbers;
            SentCultureCode = CultureCode;
        }

        private async Task PostPlate()
        {
            if(SentNumbers == Numbers && SentCultureCode == CultureCode)
            {
                await _plateService.PostPlateAsync(Numbers, CultureCode);
            }
        }
    }
}
