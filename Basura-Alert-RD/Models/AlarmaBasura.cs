using System;

namespace Basura_Alert_RD.Models;

public class AlarmaBasura
{
    public string Sector { get; set; } = string.Empty;
    public string ReportadoPor { get; set; } = string.Empty;
    public DateTime FechaHora { get; set; } = DateTime.Now;
}