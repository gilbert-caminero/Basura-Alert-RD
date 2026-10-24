using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Basura_Alert_RD.Models;

namespace Basura_Alert_RD.Services;

public static class AlarmaService
{
    private static readonly List<AlarmaBasura> _historialAlertas = new()
    {
        new AlarmaBasura { Sector = "Palacio de Engombe", ReportadoPor = "Admin", FechaHora = DateTime.Now.AddMinutes(-15) },
        new AlarmaBasura { Sector = "Calle Los Pinos", ReportadoPor = "Vecino", FechaHora = DateTime.Now.AddHours(-1) }
    };

    // Propiedad requerida para los puntos de reciclaje en memoria
    public static List<PuntoReciclaje> PuntosReciclaje { get; set; } = new()
    {
        new PuntoReciclaje { Id = 1, NombrePunto = "Punto Engombe", Ubicacion = "Zona Universitaria", Horario = "8:00 AM - 5:00 PM" }
    };

    public static async Task<bool> EmitirAlarmaAsync(string sector, string usuario)
    {
        await Task.Delay(200);
        var nuevaAlarma = new AlarmaBasura
        {
            Sector = sector,
            ReportadoPor = string.IsNullOrEmpty(usuario) ? "Vecino" : usuario,
            FechaHora = DateTime.Now
        };
        _historialAlertas.Insert(0, nuevaAlarma);
        return true;
    }

    public static async Task<List<AlarmaBasura>> ObtenerAlertasRecientesAsync()
    {
        await Task.Delay(100);
        return _historialAlertas;
    }
}