namespace SegundoParcial.Models;

public class Area
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual List<Deposito> Depositos { get; set; }


}