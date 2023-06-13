using SegundoParcial.Models;

namespace SegundoParcial.Services;

public interface IDepositoService
{
    void Create(Deposito obj);
    List<Deposito> GetAll(string nameFilter);
    List<Deposito> GetAll();
    void Update(Deposito obj);
    void Delete(int id);
    Deposito? GetById(int id);


}