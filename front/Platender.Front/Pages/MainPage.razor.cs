
using MudBlazor;

namespace Platender.Front.Pages
{
	public partial class MainPage
	{
		private List<string> BestDrivers = new();
		private IList<string> _source = new List<string>() { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
		protected override void OnInitialized()
		{
			BestDrivers.Add("ADAM MAŁYSZ");
			BestDrivers.Add("ROBERT KUBICA");
		}
	}
}
