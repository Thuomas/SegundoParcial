using SegundoParcial.Models;

namespace SegundoParcial.Services;
public interface IEquipoService
{
    void Create(Equipo obj);
    List<Equipo> GetAll(string nameFilter);
    List<Equipo> GetAll();
    void Update(Equipo obj);
    void Delete(int id);
    Equipo? GetById(int id);


}