using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace PlayedOff.Web.Auth;

public partial class LoginDisplay
{
    [Inject] private NavigationManager Navigation { get; set; } = null!;

    private void BeginSignOut()
    {
        Navigation.NavigateToLogout("authentication/logout");
    }

    private void BeginSignIn()
    {
        Navigation.NavigateToLogout("authentication/login");
    }
}