using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Basura_Alert_RD.Models;

namespace Basura_Alert_RD.ViewModels;

public partial class CrearAlertaViewModel : ObservableObject
{
    [ObservableProperty]
    private string titulo;

    [ObservableProperty]
    private string ubicacion;

    [ObservableProperty]
    private string descripcion;

    [ObservableProperty]
    private string errorTitulo;

    [ObservableProperty]
    private bool tieneErrorTitulo;

    [ObservableProperty]
    private string errorUbicacion;

    [ObservableProperty]
    private bool tieneErrorUbicacion;

    [ObservableProperty]
    private string errorDescripcion;

    [ObservableProperty]
    private bool tieneErrorDescripcion;

    [RelayCommand]
    private async Task GuardarAlerta()
    {
        LimpiarErrores();
        bool esValido = true;

        if (string.IsNullOrWhiteSpace(Titulo))
        {
            ErrorTitulo = "El título de la alerta es obligatorio.";
            TieneErrorTitulo = true;
            esValido = false;
        }

        if (string.IsNullOrWhiteSpace(Ubicacion))
        {
            ErrorUbicacion = "Debes indicar la ubicación del reporte.";
            TieneErrorUbicacion = true;
            esValido = false;
        }

        if (string.IsNullOrWhiteSpace(Descripcion))
        {
            ErrorDescripcion = "Proporciona una breve descripción del problema.";
            TieneErrorDescripcion = true;
            esValido = false;
        }

        if (!esValido)
            return;

        AlertasViewModel.ListaAlertas.Add(new AlarmaBasura
        {
            Titulo = Titulo,
            Ubicacion = Ubicacion,
            Sector = Ubicacion,
            Descripcion = Descripcion,
            Fecha = DateTime.Now,
            FechaHora = DateTime.Now
        });

        await Shell.Current.DisplayAlert("¡Éxito!", "La alerta ha sido creada correctamente.", "OK");
        LimpiarFormulario();

        await Shell.Current.GoToAsync("//AlertasPage");
    }

    private void LimpiarErrores()
    {
        ErrorTitulo = string.Empty;
        TieneErrorTitulo = false;
        ErrorUbicacion = string.Empty;
        TieneErrorUbicacion = false;
        ErrorDescripcion = string.Empty;
        TieneErrorDescripcion = false;
    }

    private void LimpiarFormulario()
    {
        Titulo = string.Empty;
        Ubicacion = string.Empty;
        Descripcion = string.Empty;
        LimpiarErrores();
    }
}