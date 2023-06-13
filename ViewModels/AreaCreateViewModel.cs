namespace SegundoParcial.Models;

public class AreaCreateViewModel
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual List<int> DepositoIds { get; set; }


}