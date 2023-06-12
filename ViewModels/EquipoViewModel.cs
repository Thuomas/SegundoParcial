using SegundoParcial.Models;

namespace SegundoParcial.ViewModels;
public class EquipoViewModel
{
    public List<Equipo> Equipos { get; set; } = new List<Equipo>();

    public string? NameFilter { get; set; }

    public string NombreDeposito { get; set; }

    public int Id { get; set; }

    public string NumSerie { get; set; }

    public DateOnly FechaProd { get; set; }

    public DateOnly FechaVenta { get; set; }

    public string? Comentario { get; set; }

    public int DepositoId { get; set; }


}