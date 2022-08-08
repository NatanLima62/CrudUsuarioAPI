using CrudUsuario.Services.DTOs;

namespace CrudUsuario.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> Create(UserDTO userDTO);
    Task<List<GetUserDTO>> GetAll();
    Task<GetUserDTO> GetById(int id);
    Task<GetUserDTO> GetByEmail(string email);
    Task<GetUserDTO> GetByRg(string rg);
    Task<GetUserDTO> GetByCPF(string cpf);
    Task<UserDTO> Update(UserDTO userDTO);
    Task Delete(int id);
}