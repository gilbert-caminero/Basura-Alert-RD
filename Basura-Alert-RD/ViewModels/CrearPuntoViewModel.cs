using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Basura_Alert_RD.Models;

namespace Basura_Alert_RD.ViewModels;

public partial class CrearPuntoViewModel : ObservableObject
{
    [ObservableProperty]
    private string nombrePunto;

    [ObservableProperty]
    private string direccion;

    [ObservableProperty]
    private string horario;

    [ObservableProperty]
    private string tipoMaterial = "General";

    [RelayCommand]
    private async Task GuardarPunto()
    {
        if (string.IsNullOrWhiteSpace(NombrePunto) || string.IsNullOrWhiteSpace(Direccion))
        {
            await Shell.Current.DisplayAlert("Error", "Por favor completa el nombre y la dirección del punto.", "OK");
            return;
        }

        // Creamos la entidad sincronizada con las propiedades del modelo
        var nuevoPunto = new PuntoReciclaje
        {
            Id = AlertasViewModel.ListaPuntos.Count + 1,
            Nombre = NombrePunto,
            NombrePunto = NombrePunto,
            Direccion = Direccion,
            Ubicacion = Direccion,
            Horario = string.IsNullOrWhiteSpace(Horario) ? "8:00 AM - 5:00 PM" : Horario,
            TipoMaterial = TipoMaterial
        };

        // Guardamos directamente en la lista compartida
        AlertasViewModel.ListaPuntos.Add(nuevoPunto);

        await Shell.Current.DisplayAlert("¡Éxito!", "El punto de reciclaje ha sido guardado correctamente.", "OK");

        // Limpiamos los campos del formulario
        NombrePunto = string.Empty;
        Direccion = string.Empty;
        Horario = string.Empty;
        TipoMaterial = "General";

        // Regresa a la vista anterior (Gestión General)
        await Shell.Current.GoToAsync("..");
    }
}