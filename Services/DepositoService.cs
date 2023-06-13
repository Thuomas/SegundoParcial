using SegundoParcial.Data;
using SegundoParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace SegundoParcial.Services;

public class DepositoService : IDepositoService
{
     private readonly EquipoContext _context;

    public DepositoService( EquipoContext context)
    {
        _context = context;
    }

    public void Create(Deposito obj)
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

    public List<Deposito> GetAll(string nameFilter)
    {
        var query = GetQuery();
        if (!string.IsNullOrEmpty(nameFilter))
        {
            query = query.Where(x => x.Nombre.Contains(nameFilter));
        }
        return query.ToList();
    }

    public List<Deposito> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public Deposito? GetById(int id)
    {
        var deposito = GetQuery()
            .Include(x => x.Areas)
            .FirstOrDefault(m => m.Id == id);

        return deposito;
    }

    public void Update(Deposito obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Deposito> GetQuery()
    {
        return from deposito in _context.Deposito select deposito;
    }
}