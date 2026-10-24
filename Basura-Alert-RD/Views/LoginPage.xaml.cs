using Microsoft.Maui.Controls;

namespace Basura_Alert_RD.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnIniciarSesionClicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text?.Trim();
        string clave = txtPassword.Text?.Trim();

        // 1. Validar que los campos NO estén vacíos
        if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
        {
            await DisplayAlert("Error de acceso", "Por favor ingresa tu usuario y contraseña.", "OK");
            return; // Bloquea la entrada
        }

        // 2. Validar credenciales correctas
        if (usuario == "admin" && clave == "1234")
        {
            // Habilita el Flyout y la opción de Cerrar Sesión en AppShell
            if (Shell.Current is AppShell shell)
            {
                shell.HabilitarMenuPrincipal();
            }

            // Navega a la pantalla principal
            await Shell.Current.GoToAsync("//InicioPage");
        }
        else
        {
            await DisplayAlert("Acceso denegado", "Usuario o contraseña incorrectos.", "OK");
        }
    }
}