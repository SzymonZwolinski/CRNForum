using Microsoft.AspNetCore.Components;

namespace Platender.Front.Components
{
	public partial class EUPlate : ComponentBase
	{
		[Parameter]
		public string CultureCode { get; set; }

		[Parameter]
		public string Number { get; set; }

		[Parameter]
		public Action<Guid> OnClickAction { get; set; }
		[Parameter]
		public bool DisplayFlag { get; set; }
		[Parameter]
		public string FlagSrc { get; set; }
		[Parameter]
		public string BackgroundStyle { get; set; }

		[Parameter]
		public Guid PlateId { get; set; }

		private void HandleClick()
		{
			OnClickAction?.Invoke(PlateId);
		}
	}
}
