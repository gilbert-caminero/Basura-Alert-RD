using System.Collections.ObjectModel;
using Basura_Alert_RD.Models;

namespace Basura_Alert_RD.Services;

public static class AlarmaService
{
    public static ObservableCollection<AlarmaBasura> Alertas { get; set; } = new()
    {
        new AlarmaBasura { Sector = "Palacio de Engombe", ReportadoPor = "Admin", FechaHora = DateTime.Now.AddHours(-2) },
        new AlarmaBasura { Sector = "Calle Los Pinos", ReportadoPor = "Vecino", FechaHora = DateTime.Now.AddHours(-1) }
    };

    public static ObservableCollection<PuntoReciclaje> PuntosReciclaje { get; set; } = new()
    {
        new PuntoReciclaje { Id = 1, NombrePunto = "Punto Engombe", Ubicacion = "Zona Universitaria", Horario = "8:00 AM - 5:00 PM" },
        new PuntoReciclaje { Id = 2, NombrePunto = "EcoPunto Los Pinos", Ubicacion = "Calle Principal #12", Horario = "9:00 AM - 4:00 PM" }
    };

    public static Task<ObservableCollection<AlarmaBasura>> ObtenerAlertasRecientesAsync() => Task.FromResult(Alertas);

    public static Task<bool> EmitirAlarmaAsync(string sector, string usuario)
    {
        Alertas.Insert(0, new AlarmaBasura { Sector = sector, ReportadoPor = usuario, FechaHora = DateTime.Now });
        return Task.FromResult(true);
    }

    public static Task<bool> EliminarAlarmaAsync(AlarmaBasura alerta)
    {
        if (Alertas.Contains(alerta)) { Alertas.Remove(alerta); return Task.FromResult(true); }
        return Task.FromResult(false);
    }

    public static Task<bool> AgregarPuntoReciclajeAsync(string nombre, string ubicacion, string horario)
    {
        int nuevoId = PuntosReciclaje.Count > 0 ? PuntosReciclaje.Max(p => p.Id) + 1 : 1;
        PuntosReciclaje.Insert(0, new PuntoReciclaje { Id = nuevoId, NombrePunto = nombre, Ubicacion = ubicacion, Horario = horario });
        return Task.FromResult(true);
    }

    public static Task<bool> EliminarPuntoReciclajeAsync(PuntoReciclaje punto)
    {
        if (PuntosReciclaje.Contains(punto)) { PuntosReciclaje.Remove(punto); return Task.FromResult(true); }
        return Task.FromResult(false);
    }
}