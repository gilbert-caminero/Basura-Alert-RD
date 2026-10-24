using Basura_Alert_RD.Services;

namespace Basura_Alert_RD.Views;

public partial class AlertasPage : ContentPage
{
    public AlertasPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Carga las alertas
        collectionAlertas.ItemsSource = await AlarmaService.ObtenerAlertasRecientesAsync();

        // Carga los puntos de reciclaje en memoria
        collectionPuntos.ItemsSource = AlarmaService.PuntosReciclaje;
    }
}