using Microsoft.AspNetCore.Components;
using Platender.Front.Models;
using Platender.Front.Services;

namespace Platender.Front.Pages
{
    public partial class PlateView : ComponentBase
    {
        [Inject]
        private IPlateService _plateService { get; set; }

		[Parameter]
		public Guid plateId { get; set; }

		private Plate plate = new Plate();

		protected override async Task OnInitializedAsync()
		{
			plate = await _plateService.GetPlateByIdAsync(plateId);
		}
	}
}