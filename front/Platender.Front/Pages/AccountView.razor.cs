using Microsoft.AspNetCore.Components;
using Platender.Front.Components;
using Platender.Front.Models;
using Platender.Front.Services;
using Platender.Front.State;

namespace Platender.Front.Pages
{
    public partial class AccountView : ComponentBase
    {
        [Inject]
        private IUserService _userService { get; set; }
        [Inject]
        private AccountState AccountState { get; set; }

        private bool _isLoginDisplayed = false;
        private bool _isRegisterDisplayed = false;
        private bool _isPromptToLoginDisplayed = true;
        private bool _isUserLoggedIn = false;

        private bool _isChangePasswordDisplayed = false;

        private Login LoginComponent;

        private User UserAccount = new();

        protected override async Task OnInitializedAsync()
        {
            AccountState.OnChange += StateHasChanged;
            
            UserAccount = await _userService.GetAuthorizedUser();
            if (!string.IsNullOrWhiteSpace(UserAccount.Username))
            {
                _isUserLoggedIn = true;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (AccountState.IsLoginSuccesful)
            {
                _isPromptToLoginDisplayed = false;
                _isLoginDisplayed = false;
                _isUserLoggedIn = true;
            }

            if(_isChangePasswordDisplayed && AccountState.IsChangePasswordSent)
            {
                _isChangePasswordDisplayed = false;
                AccountState.IsChangePasswordSent = false;
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task ShowLoginField()
        {
            _isLoginDisplayed = true;
            _isPromptToLoginDisplayed = false;
        }

        private async Task ShowRegisterField()
        {
            _isRegisterDisplayed = true;
            _isPromptToLoginDisplayed = false;
        }

        private async Task ReturnToPromtToLogin()
        {
            _isLoginDisplayed = false;
            _isRegisterDisplayed = false;

            _isPromptToLoginDisplayed = true;
        }

        private async Task ShowChangePasswordField()
        {
            _isChangePasswordDisplayed = true;
        }

        public void Dispose()
        {
            AccountState.OnChange -= StateHasChanged;
        }
    }
}
