using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Basura_Alert_RD.Models;
using System.Collections.ObjectModel;

namespace Basura_Alert_RD.ViewModels;

public partial class AlertasViewModel : ObservableObject
{
    // Colección estática de Alertas Ciudadanas
    public static ObservableCollection<AlarmaBasura> ListaAlertas { get; set; } = new ObservableCollection<AlarmaBasura>
    {
        new AlarmaBasura
        {
            Titulo = "Vertedero improvisado",
            Sector = "Palacio de Engombe",
            Ubicacion = "Palacio de Engombe",
            Descripcion = "Basura acumulada cerca del parque.",
            ReportadoPor = "Admin",
            Fecha = DateTime.Now,
            FechaHora = DateTime.Now
        },
        new AlarmaBasura
        {
            Titulo = "Escombros en vía pública",
            Sector = "Calle Los Pinos",
            Ubicacion = "Calle Los Pinos",
            Descripcion = "Restos de construcción obstaculizando el paso.",
            ReportadoPor = "Vecino",
            Fecha = DateTime.Now,
            FechaHora = DateTime.Now
        }
    };

    public ObservableCollection<AlarmaBasura> Alertas => ListaAlertas;

    // Colección estática de Puntos de Reciclaje
    public static ObservableCollection<PuntoReciclaje> ListaPuntos { get; set; } = new ObservableCollection<PuntoReciclaje>
    {
        new PuntoReciclaje
        {
            Id = 1,
            Nombre = "Bayona",
            NombrePunto = "Bayona",
            Direccion = "Calle Principal",
            Ubicacion = "Calle Principal",
            TipoMaterial = "Plástico y Papel",
            Horario = "8:00 AM - 5:00 PM"
        },
        new PuntoReciclaje
        {
            Id = 2,
            Nombre = "Punto Engombe",
            NombrePunto = "Punto Engombe",
            Direccion = "Zona Universitaria",
            Ubicacion = "Zona Universitaria",
            TipoMaterial = "Vidrio y Metales",
            Horario = "9:00 AM - 4:00 PM"
        },
        new PuntoReciclaje
        {
            Id = 3,
            Nombre = "EcoPunto Los Pinos",
            NombrePunto = "EcoPunto Los Pinos",
            Direccion = "Calle Principal #12",
            Ubicacion = "Calle Principal #12",
            TipoMaterial = "Multimaterial",
            Horario = "8:00 AM - 6:00 PM"
        }
    };

    public ObservableCollection<PuntoReciclaje> PuntosReciclaje => ListaPuntos;

    [RelayCommand]
    private async Task EditarAlerta(AlarmaBasura alerta)
    {
        if (alerta == null) return;

        // 1. Modificar Sector
        string nuevoSector = await Shell.Current.DisplayPromptAsync("Editar Alerta", "Modificar Sector:", initialValue: alerta.Sector);
        if (string.IsNullOrWhiteSpace(nuevoSector)) return;

        // 2. Modificar Reportado Por
        string nuevoReporte = await Shell.Current.DisplayPromptAsync("Editar Alerta", "Modificar Reportado Por:", initialValue: alerta.ReportadoPor);
        if (string.IsNullOrWhiteSpace(nuevoReporte)) return;

        // 3. Modificar Hora y Fecha
        string nuevaHoraStr = await Shell.Current.DisplayPromptAsync("Editar Alerta", "Modificar Hora/Fecha (ej. 10:30 PM):", initialValue: alerta.FechaHora.ToString("g"));

        alerta.Sector = nuevoSector;
        alerta.Ubicacion = nuevoSector;
        alerta.ReportadoPor = nuevoReporte;

        if (DateTime.TryParse(nuevaHoraStr, out DateTime fechaHoraConvertida))
        {
            alerta.FechaHora = fechaHoraConvertida;
            alerta.Fecha = fechaHoraConvertida;
        }
        else
        {
            alerta.FechaHora = DateTime.Now;
            alerta.Fecha = DateTime.Now;
        }

        await Shell.Current.DisplayAlert("¡Éxito!", "La alerta y su hora han sido actualizadas.", "OK");
    }

    [RelayCommand]
    private async Task EliminarAlerta(AlarmaBasura alerta)
    {
        if (alerta == null) return;
        bool confirmar = await Shell.Current.DisplayAlert("Eliminar", $"¿Deseas eliminar la alerta de '{alerta.Sector}'?", "Sí", "No");
        if (confirmar) ListaAlertas.Remove(alerta);
    }

    [RelayCommand]
    private async Task EditarPunto(PuntoReciclaje punto)
    {
        if (punto == null) return;

        string nuevoNombre = await Shell.Current.DisplayPromptAsync("Editar Punto", "Modificar Nombre del Punto:", initialValue: punto.Nombre);
        if (string.IsNullOrWhiteSpace(nuevoNombre)) return;

        string nuevaDireccion = await Shell.Current.DisplayPromptAsync("Editar Punto", "Modificar Dirección:", initialValue: punto.Direccion);
        if (string.IsNullOrWhiteSpace(nuevaDireccion)) return;

        string nuevoHorario = await Shell.Current.DisplayPromptAsync("Editar Punto", "Modificar Horario:", initialValue: punto.Horario);

        punto.Nombre = nuevoNombre;
        punto.NombrePunto = nuevoNombre;
        punto.Direccion = nuevaDireccion;
        punto.Ubicacion = nuevaDireccion;
        if (!string.IsNullOrWhiteSpace(nuevoHorario)) punto.Horario = nuevoHorario;

        await Shell.Current.DisplayAlert("¡Éxito!", "El punto de reciclaje ha sido actualizado.", "OK");
    }

    [RelayCommand]
    private async Task EliminarPunto(PuntoReciclaje punto)
    {
        if (punto == null) return;
        bool confirmar = await Shell.Current.DisplayAlert("Eliminar", $"¿Deseas eliminar '{punto.Nombre}'?", "Sí", "No");
        if (confirmar) ListaPuntos.Remove(punto);
    }
}