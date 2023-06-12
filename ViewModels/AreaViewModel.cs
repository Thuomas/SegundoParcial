using SegundoParcial.Models;

namespace SegundoParcial.ViewModels;

public class AreaViewModel
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual List<Deposito> Depositos { get; set; } = new List<Deposito>();



}