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

        private async Task GetPlates()
        {
            _plates = await _plateService.GetPlatesByNumbersAsync(Numbers, CultureCode);
        }
    }
}
