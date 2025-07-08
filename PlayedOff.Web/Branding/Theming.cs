using MudBlazor;

namespace PlayedOff.Web.Branding
{
    public static class Theming
    {
        public static MudTheme Theme = new()
        {
            PaletteLight = new PaletteLight
            {
                Black = "#111111",
                Background = "#F5F7FA",
                Surface = "#F2F3F4",
                DrawerBackground = "#F0F2F5",
                AppbarBackground = "#202124",
                AppbarText = "#F2F3F4",
                TextPrimary = "#222222",
                TextSecondary = "#555555",
                DrawerText = "#4A4A4A",
                DrawerIcon = "#4A4A4A",
                Primary = "#d55b59",    
                Secondary = "#4E9FB3",
                Success = "#4CAF50",
                Warning = "#FFC107",
                Error = "#F44336",
                Dark = "#E0E0E0",
            },
            PaletteDark = new PaletteDark
            {
                Black = "#121212",
                Background = "#1C1C1E",
                Surface = "#232325",
                DrawerBackground = "#1A1A1C",
                AppbarBackground = "#202124",
                AppbarText = "#F2F3F4",
                TextPrimary = "#E0E0E0",
                TextSecondary = "#A0A0A0",
                DrawerText = "#CFCFCF",
                DrawerIcon = "#CFCFCF",
                Primary = "#f6ab42",
                Secondary = "#4E9FB3",
                Success = "#6FBF73",
                Warning = "#FFB547",
                Error = "#FF6B6B",
                Dark = "#2C2C2E",
            },

            LayoutProperties = new LayoutProperties
            {
                DefaultBorderRadius = "6px",
            },
            Typography = new Typography
            {
                Default = new DefaultTypography
                {
                    FontFamily = new[] { "Segoe UI", "sans-serif" },
                    FontSize = "0.95rem",
                },
                H1 = new H1Typography { FontSize = "2.2rem", FontWeight = "600" },
                H2 = new H2Typography { FontSize = "1.8rem", FontWeight = "500" },
                H3 = new H3Typography { FontSize = "1.5rem", FontWeight = "500" },
                Button = new ButtonTypography { FontWeight = "600", LetterSpacing = "0.4px" },
            }
        };
    }
}
