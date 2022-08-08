using CrudUsuario.Domain.Entities;

namespace CrudUsuario.Infra.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email);
    Task<User> GetByRG(string rg);
    Task<User> GetByCPF(string cpf);
    Task<User> Exists(string email, string rg, string cfp);
}