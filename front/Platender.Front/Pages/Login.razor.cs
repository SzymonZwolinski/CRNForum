using Microsoft.AspNetCore.Components;
using MudBlazor;
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

		private string PasswordMatch(string arg)
		{
			if (pwField1.Value != arg)
				return "Passwords don't match";
			return null;
		}

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
