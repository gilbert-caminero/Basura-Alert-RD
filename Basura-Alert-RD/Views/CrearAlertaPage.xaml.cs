using System;
using Microsoft.Maui.Controls;
using Basura_Alert_RD.Services;

namespace Basura_Alert_RD.Views;

public partial class CrearAlertaPage : ContentPage
{
    public CrearAlertaPage()
    {
        InitializeComponent();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        // Validación de campos obligatorios
        if (string.IsNullOrWhiteSpace(TxtSector?.Text))
        {
            await DisplayAlert("Advertencia", "El campo Sector es obligatorio.", "Aceptar");
            return;
        }

        // Guardado en memoria
        await AlarmaService.EmitirAlarmaAsync(TxtSector.Text, "Admin");

        await DisplayAlert("Éxito", "Alerta registrada correctamente.", "Aceptar");

        // Limpieza y redirección
        TxtSector.Text = string.Empty;
        await Shell.Current.GoToAsync("//AlertasPage");
    }
}