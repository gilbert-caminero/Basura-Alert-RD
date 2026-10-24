using Microsoft.Maui.Controls;
using System.Windows.Input;
using Basura_Alert_RD.Views;

namespace Basura_Alert_RD;

public partial class AppShell : Shell
{
    public ICommand CerrarSesionCommand { get; }

    public AppShell()
    {
        // Comando para cerrar sesión
        CerrarSesionCommand = new Command(async () =>
        {
            FlyoutBehavior = FlyoutBehavior.Disabled;
            await GoToAsync("//LoginPage");
        });

        BindingContext = this;

        // 1. Login (Sin Flyout)
        var loginContent = new ShellContent
        {
            Title = "Login",
            ContentTemplate = new DataTemplate(typeof(LoginPage)),
            Route = "LoginPage"
        };
        SetFlyoutItemIsVisible(loginContent, false);
        SetTabBarIsVisible(loginContent, false);
        Items.Add(loginContent);

        // 2. Vistas del Menú Principal
        var mainFlyoutItem = new FlyoutItem
        {
            Title = "Menú Principal",
            FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems
        };

        mainFlyoutItem.Items.Add(new ShellContent
        {
            Title = "Inicio",
            ContentTemplate = new DataTemplate(typeof(InicioPage)),
            Route = "InicioPage"
        });

        mainFlyoutItem.Items.Add(new ShellContent
        {
            Title = "Alertas y Registros",
            ContentTemplate = new DataTemplate(typeof(AlertasPage)),
            Route = "AlertasPage"
        });

        mainFlyoutItem.Items.Add(new ShellContent
        {
            Title = "Crear Registro",
            ContentTemplate = new DataTemplate(typeof(CrearAlertaPage)),
            Route = "CrearAlertaPage"
        });

        Items.Add(mainFlyoutItem);

        // 3. Opción "Cerrar sesión" en el Flyout
        var menuItem = new MenuItem
        {
            Text = "Cerrar sesión",
            Command = CerrarSesionCommand
        };
        Items.Add(menuItem);

        // Ocultar menú lateral al iniciar la app
        FlyoutBehavior = FlyoutBehavior.Disabled;
    }

    public void HabilitarMenuPrincipal()
    {
        FlyoutBehavior = FlyoutBehavior.Flyout;
    }
}