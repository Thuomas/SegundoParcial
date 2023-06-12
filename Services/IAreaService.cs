using SegundoParcial.Models;

namespace SegundoParcial.Services;

public interface IAreaService
{
    void Create(Area obj);
    List<Area> GetAll(string nameFilter);
    List<Area> GetAll();
    void Update(Area obj);
    void Delete(int id);
    Area? GetById(int id);


}