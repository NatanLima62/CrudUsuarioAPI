using CrudUsuario.Domain.Entities;
using CrudUsuario.Infra.Contexts;
using CrudUsuario.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudUsuario.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private readonly dbCrudUsuarioContext _context;

    public BaseRepository(dbCrudUsuarioContext context)
    {
        _context = context;
    }
    
    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<List<T>> GetAll()
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();

        return obj;
    }

    public virtual async Task<T> GetById(int id)
    {
        var obj = await _context.Set<T>()
            .Where(x => x.Id == id)
            .AsNoTracking()
            .ToListAsync();

        return obj.FirstOrDefault();
    }

    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> Delete(int id)
    {
        var obj = await GetById(id);

        if (obj != null)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        return obj;
    }
}