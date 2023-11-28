using Microsoft.AspNetCore.Components;
using Platender.Front.Models;

namespace Platender.Front.Pages
{
    public partial class PlatesView : ComponentBase
    {
		[Parameter]
		public Plate plate { get; set; }
    }
}