namespace Basura_Alert_RD.Views;

public partial class InicioPage : ContentPage
{
    public InicioPage()
    {
        InitializeComponent();
    }

    private async void OnCrearAvisoClicked(object sender, EventArgs e)
    {
        // Navega a la pestaña CrearAlertaPage
        await Shell.Current.GoToAsync("//CrearAlertaPage");
    }

    private async void OnVerAlertasClicked(object sender, EventArgs e)
    {
        // Navega a la pestaña AlertasPage
        await Shell.Current.GoToAsync("//AlertasPage");
    }
}