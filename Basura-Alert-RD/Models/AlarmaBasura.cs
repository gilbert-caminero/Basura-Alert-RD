using System;

namespace Basura_Alert_RD.Models;

public class AlarmaBasura
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Sector { get; set; } = string.Empty;
    public string ReportadoPor { get; set; } = string.Empty;
    public DateTime FechaHora { get; set; } = DateTime.Now;

    // Propiedad formateada para mostrar la hora en la interfaz
    public string HoraFormateada => FechaHora.ToString("hh:mm tt");
}