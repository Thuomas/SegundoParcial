using SegundoParcial.Data;
using SegundoParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace SegundoParcial.Services;

public class AreaService : IAreaService
{
    private readonly EquipoContext _context;

    public AreaService( EquipoContext context)
    {
        _context = context;
    }

    public void Create(Area obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var borrar = GetById(id);
        if(borrar !=null)
        {
            _context.Remove(borrar);
            _context.SaveChanges();
        }
    }

    public List<Area> GetAll(string nameFilter)
    {
        var query = GetQuery();
        if (!string.IsNullOrEmpty(nameFilter))
        {
            query = query.Where(x => x.Nombre.Contains(nameFilter));
        }
        return query.ToList();
    }

    public List<Area> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public Area? GetById(int id)
    {
        var area = _context.Area.
        Include(x =>x.Depositos).
        FirstOrDefault(x =>x.Id == id);

        return area;
    }

    public void Update(Area obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Area> GetQuery()
    {
        return from area in _context.Area select area;
    }
}