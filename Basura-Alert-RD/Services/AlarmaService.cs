using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Basura_Alert_RD.Models;

namespace Basura_Alert_RD.Services;

public class AlarmaService
{
    private static readonly List<AlarmaBasura> _historialAlertas = new();

    public async Task<bool> EmitirAlarmaAsync(string sector, string usuario)
    {
        await Task.Delay(300); // Simulación de envío en red

        var nuevaAlarma = new AlarmaBasura
        {
            Sector = sector,
            ReportadoPor = usuario,
            FechaHora = DateTime.Now
        };

        _historialAlertas.Insert(0, nuevaAlarma);
        return true;
    }

    public async Task<List<AlarmaBasura>> ObtenerAlertasRecientesAsync()
    {
        await Task.Delay(100);
        return _historialAlertas;
    }
}