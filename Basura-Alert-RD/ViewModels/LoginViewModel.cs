using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Basura_Alert_RD.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string usuario;

    [ObservableProperty]
    private string contrasena;

    [RelayCommand]
    private async Task IniciarSesion()
    {
        if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Contrasena))
        {
            await Shell.Current.DisplayAlert("Campos Vacíos", "Por favor ingresa tu usuario y contraseña.", "OK");
            return;
        }

        if (Usuario == "admin" && Contrasena == "1234")
        {
            Usuario = string.Empty;
            Contrasena = string.Empty;

            // 1. Habilitar el menú lateral y las opciones generales del sistema
            if (Shell.Current is AppShell appShell)
            {
                appShell.HabilitarMenu();
            }

            // 2. Navegar al Inicio (donde verás tus opciones y atajos)
            await Shell.Current.GoToAsync("//InicioPage");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
        }
    }
}