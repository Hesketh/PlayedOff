using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace PlayedOff.Web.Layout
{
    public partial class MainLayout
    {
        private MudThemeProvider _mudThemeProvider = null!;
        private ErrorBoundary _errorBoundary = null!;

        public bool DarkMode { get; set; }
        public bool DrawerOpen { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                DarkMode = await _mudThemeProvider.GetSystemDarkModeAsync();
                await _mudThemeProvider.WatchSystemDarkModeAsync(OnSystemDarkModeChanged);
                StateHasChanged();
            }
        }

        private Task OnSystemDarkModeChanged(bool newValue)
        {
            DarkMode = newValue;
            StateHasChanged();
            return Task.CompletedTask;
        }

        private void RecoverErrorBoundary()
        {
            _errorBoundary.Recover();
        }
    }
}
