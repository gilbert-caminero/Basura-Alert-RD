using CommunityToolkit.Mvvm.Input;
using Basura_Alert_RD.Views;

namespace Basura_Alert_RD;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
    }

    // Método para habilitar el menú lateral tras un login exitoso
    public void HabilitarMenu()
    {
        FlyoutBehavior = FlyoutBehavior.Flyout;
    }

    [RelayCommand]
    private async Task CerrarSesion()
    {
        FlyoutIsPresented = false;

        bool confirmar = await DisplayAlert("Cerrar Sesión", "¿Estás seguro de que deseas salir?", "Sí", "No");
        if (confirmar)
        {
            // Bloqueamos de nuevo el menú lateral antes de volver al login
            FlyoutBehavior = FlyoutBehavior.Disabled;
            await GoToAsync("//LoginPage");
        }
    }
}