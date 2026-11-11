namespace Basura_Alert_RD.Views;

public partial class InicioPage : ContentPage
{
    public InicioPage()
    {
        InitializeComponent();
    }

    private async void OnCrearAlertaClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CrearAlertaPage");
    }

    private async void OnCrearPuntoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CrearPuntoPage");
    }

    private async void OnVerAlertasClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AlertasPage");
    }
}