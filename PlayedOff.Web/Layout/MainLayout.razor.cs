using MudBlazor;

namespace PlayedOff.Web.Layout
{
    public partial class MainLayout
    {
        public bool DarkMode { get; set; }
        public bool DrawerOpen { get; set; }

        private MudThemeProvider _mudThemeProvider = null!;

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
    }
}
