using Microsoft.AspNetCore.Components;
using Platender.Front.Models;
using Platender.Front.Services;

namespace Platender.Front.Pages
{
	public partial class Login : ComponentBase
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

		private async void LoginUser()
		{
			await _authService.LoginAsync(InputAccount);

			_navigationManager.NavigateTo("/");
		}

	}
}
