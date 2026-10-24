namespace Basura_Alert_RD;

public class App : Application
{
    public App()
    {
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());

        // Forzar a que la app inicie en la página de Login
        Shell.Current?.GoToAsync("//LoginPage");

        return window;
    }
}