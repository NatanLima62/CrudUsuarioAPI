using CrudUsuario.Domain.Entities;

namespace CrudUsuario.Infra.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    Task<T> Create(T obj);
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Update(T obj);
    Task<T> Delete(int id);
}