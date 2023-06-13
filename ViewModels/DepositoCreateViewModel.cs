namespace SegundoParcial.Models;

public class DepositoCreateViewModel
{

     public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual List<int> AreaIds { get; set; }
}