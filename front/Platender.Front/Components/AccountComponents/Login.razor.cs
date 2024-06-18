using Microsoft.AspNetCore.Components;
using MudBlazor;
using Platender.Front.Services;
using Platender.Front.State;

namespace Platender.Front.Components.AccountComponents
{
	public partial class Login : ComponentBase
	{
		[Inject]
		private IAuthService _authService { get; set; }
		[CascadingParameter]
		private AccountState AccountState { get; set; }
		[Parameter]
		public EventCallback<string> OnLoginSuccesfull { get; set; }
		private Models.Account InputAccount;
		private bool success;
		private string[] errors = { };
		private MudTextField<string> pwField1;
		private MudForm form;

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
			await _authService.LoginAsync(InputAccount, AccountState);
			
			await OnLoginSuccesfull.InvokeAsync();
		}
	}
}
