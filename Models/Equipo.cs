namespace SegundoParcial.Models;

public class Equipo
{
    public int Id { get; set; }

    public string NumSerie { get; set; }

    public DateOnly FechaProd { get; set; }

    public DateOnly FechaVenta { get; set; }

    public string? Comentario { get; set; }

    public int DepositoId { get; set; }

    public virtual Deposito Deposito { get; set; }


}