using Microsoft.AspNetCore.Components;
using MudBlazor;
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

		bool success;
		string[] errors = { };
		MudTextField<string> pwField1;
		MudForm form;

		private IEnumerable<string> PasswordStrength(string pw)
		{
			if (string.IsNullOrWhiteSpace(pw))
			{
				yield return "Password is required!";
				yield break;
			}
		}

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
