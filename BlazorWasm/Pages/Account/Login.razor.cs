using BlazorWasm.Components;
using BlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasm.Pages.Account
{
    public partial class Login
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] ApiService ApiService { get; set; }

        private string username;
        private string password;
        private string ErrorMessage;
        private bool IsAuthenticating = true;
        protected async override Task OnInitializedAsync()
        {
            var auth = await authenticationStateTask;

            if (auth.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/home");
                return;
            }

            IsAuthenticating = false;
        }

        private async Task LoginAsync()
        {
            if ((string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username)) && (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password)))
            {
                ErrorMessage = "Username and password are required.";
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                ErrorMessage = "Username is required.";
                return;
            }

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                ErrorMessage = "Password is required.";
                return;
            }

            IsAuthenticating = true;
            var response = await ApiService.Login(username, password);
            if (string.IsNullOrEmpty(response.Authtoken))
            {
                ErrorMessage = response.LoginResponse;
                IsAuthenticating = false;
                return;
            }

            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).UpdateAuthenticationState(response);
            StateHasChanged();
            NavigationManager.NavigateTo("/home");

        }
    }
}