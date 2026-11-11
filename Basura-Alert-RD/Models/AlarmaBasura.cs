namespace Basura_Alert_RD.Models;

public class AlarmaBasura
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Sector { get; set; }
    public string Ubicacion { get; set; }
    public string ReportadoPor { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.Now;
    public DateTime Fecha { get; set; } = DateTime.Now;
}