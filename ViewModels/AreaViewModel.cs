using SegundoParcial.Models;

namespace SegundoParcial.ViewModels;

public class AreaViewModel
{
    public int Id { get; set; }

    public string Nombre { get; set; }
    
    public List<Deposito> Depositos { get; set; } = new List<Deposito>();
    public List<Area> Areas { get; set; } = new List<Area>();


}