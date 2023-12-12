using Microsoft.AspNetCore.Components;
using Platender.Front.Models;
using Platender.Front.Services;

namespace Platender.Front.Pages
{
	public partial class Register : ComponentBase
	{
		[Inject]
		private IAuthService _authService { get; set; }
		[Inject]
		private NavigationManager _navigationManager { get; set; }

		private Account InputAccount;


		protected override Task OnInitializedAsync()
		{
			InputAccount ??= new();

			return base.OnInitializedAsync();
		}

		private async void RegisterUser()
		{
			await _authService.RegisterAsync(InputAccount);

			_navigationManager.NavigateTo("/");
		}
	}
}
