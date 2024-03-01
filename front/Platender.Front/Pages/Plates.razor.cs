using Microsoft.AspNetCore.Components;
using Platender.Front.Helpers;
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

        private PagedData<Plate> _plates;
        private bool IsGetPlatesSend = false;
        private string SentNumbers;
        private CultureCode? SentCultureCode;
        private int Page = 1;
        
        private async Task GetPlates()
        {
            _plates = await _plateService.GetPlatesByNumbersAsync(
                Numbers,
                CultureCode,
                Page);

            IsGetPlatesSend = true;
            SentNumbers = Numbers;
            SentCultureCode = CultureCode;
        }

        private async Task PostPlate()
        {
            if(SentNumbers != Numbers || SentCultureCode != CultureCode) 
            {
                return; 
            }

            await _plateService.PostPlateAsync(Numbers, CultureCode);
        }

        private async Task NextPageAsync()
        {
            Page += 1;
            await GetPlates();
        }
    }
}
