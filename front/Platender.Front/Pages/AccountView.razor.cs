using Microsoft.AspNetCore.Components;
using Platender.Front.Components.AccountComponents;
using Platender.Front.Models;
using Platender.Front.Services;
using Platender.Front.State;

namespace Platender.Front.Pages
{
    public partial class AccountView : ComponentBase
    {
        [Inject]
        private IUserService _userService { get; set; }
        [CascadingParameter]
        private AccountState AccountState { get; set; }

        private bool _isLoginDisplayed = false;
        private bool _isRegisterDisplayed = false;
        private bool _isPromptToLoginDisplayed = true;
        private bool _isUserLoggedIn = false;
        private bool _isGeneralUserInformationDisplayed = false;
        private bool _isUserFavouritePlatesDisplayed = false;

        private bool _isChangePasswordDisplayed = false;

        private Login LoginComponent;

        private User UserAccount = new();

        protected override async Task OnInitializedAsync()
        {
            //AccountState.OnChange += StateHasChanged;

            UserAccount = await _userService.GetAuthorizedUser();
            if (!string.IsNullOrWhiteSpace(UserAccount.Username))
            {
                _isUserLoggedIn = true;
                _isGeneralUserInformationDisplayed = true;
            }
        }

        protected override bool ShouldRender()
        {
            if (AccountState.IsLoginSuccesful)
            {
                _isUserLoggedIn = true;
                _isPromptToLoginDisplayed = false;
                _isLoginDisplayed = false;   
                _isGeneralUserInformationDisplayed = true;
            }

            if (_isChangePasswordDisplayed && AccountState.IsChangePasswordSent)
            {
                _isChangePasswordDisplayed = false;
                AccountState.IsChangePasswordSent = false;
            }
            
            return true;
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

        private async Task ShowUserFavouritePlates()
        {
            _isGeneralUserInformationDisplayed = false;
            _isUserFavouritePlatesDisplayed = true;
        }

        private async Task ReturnToUserGeneralInformation()
        {
            _isGeneralUserInformationDisplayed = true;
            _isUserFavouritePlatesDisplayed = false;
        }

        private void RevertToStart()
        {
            _isUserLoggedIn = false;
            _isLoginDisplayed = true;
            _isPromptToLoginDisplayed = true;
            _isLoginDisplayed = false;
            _isRegisterDisplayed = false;
            _isChangePasswordDisplayed = false;  
            _isGeneralUserInformationDisplayed = false;
            _isUserFavouritePlatesDisplayed = false;
        }

        public void Dispose()
        {
            AccountState.OnChange -= StateHasChanged;
        }
    }
}
