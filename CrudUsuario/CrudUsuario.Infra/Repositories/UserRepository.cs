using CrudUsuario.Domain.Entities;
using CrudUsuario.Infra.Contexts;
using CrudUsuario.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudUsuario.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly dbCrudUsuarioContext _context;

    public UserRepository(dbCrudUsuarioContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<User> GetByEmail(string email)
    {
        var user = await _context.Set<User>()
            .Where(user => user.Email == email)
            .AsNoTracking()
            .ToListAsync();
        
        return user.FirstOrDefault();
    }

    public virtual async Task<User> GetByRG(string rg)
    {
        var user = await _context.Set<User>()
            .Where(user => user.RG == rg)
            .AsNoTracking()
            .ToListAsync();

        return user.FirstOrDefault();
    }

    public virtual async Task<User> GetByCPF(string cpf)
    {
        var user = await _context.Set<User>()
            .Where(user => user.CPF == cpf)
            .AsNoTracking()
            .ToListAsync();

        return user.FirstOrDefault();
    }
}