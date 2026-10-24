namespace Basura_Alert_RD.Models;

public class ReporteCiudadano
{
    public int Id { get; set; }
    public string Sector { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
}