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

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        public string Numbers;
        public CultureCode? CultureCode;

        private bool _processing = false;
        private List<Plate> _plates;
        private bool IsGetPlatesSend = false;
        private string SentNumbers;
        private CultureCode? SentCultureCode;
        private int Page = 1;
        private int MaxPage;

        private async Task GetPlates()
        {
            _processing = true;
            try
            {
                var pagedPlates = await _plateService.GetPlatesByNumbersAsync(
                    Numbers,
                    CultureCode,
                    Page);

                _plates.AddRange(pagedPlates.Items);
         
                IsGetPlatesSend = true;
                SentNumbers = Numbers;
                SentCultureCode = CultureCode;
                MaxPage = (pagedPlates.TotalItems + 9) / 10;
            }
            catch (Exception e)
            {
                _processing = false;
                return;
            }

            _processing = false;
            StateHasChanged();
        }

        private async Task PostPlate()
        {
            if (SentNumbers != Numbers || SentCultureCode != CultureCode)
            {
                return;
            }

            await _plateService.PostPlateAsync(Numbers, CultureCode);
        }

        private async Task NextPageAsync()
        {
            Page ++;
            await GetPlates();
        }

        private void MoveToPlate(Guid plateId)
        {
            _navigationManager.NavigateTo("/plates/" + plateId.ToString());
        }

        private async Task HandleEndOfInfinityLoad()
        {
            if(Page > MaxPage)
			{
				return;
			}
            
            await NextPageAsync();            
        }
    }
}
