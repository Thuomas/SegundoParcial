using SegundoParcial.Models;

namespace SegundoParcial.ViewModels;

public class DepositoViewModel
{
    public int Id { get; set; }
    public string NombreDeposito { get; set; }

    public List<Deposito> Depositos { get; set; } = new List<Deposito>();
    public List<Equipo> Equipos { get; set; } = new List<Equipo>();
    public List<Area> Areas { get; set; } = new List<Area>();
    public string? NameFilter { get; set; }  

}