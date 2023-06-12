using SegundoParcial.Models;

namespace SegundoParcial.ViewModels;

public class DepositoViewModel
{
    public int Id { get; set; }
    public List<Equipo> Equipos { get; set; } = new List<Equipo>();

    public string? NameFilter { get; set; }

    public string NombreDeposito { get; set; }


}