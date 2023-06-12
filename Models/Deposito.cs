namespace SegundoParcial.Models;

public class Deposito
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual List<Area> Areas { get; set; }

    public virtual List<Equipo> Equipos { get; set; }

}