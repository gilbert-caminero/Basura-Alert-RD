namespace Basura_Alert_RD.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Navegar a la pestaña principal (Inicio)
        await Shell.Current.GoToAsync("//InicioPage");
    }
}