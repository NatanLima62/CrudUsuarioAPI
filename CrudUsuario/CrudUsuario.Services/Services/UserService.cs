using AutoMapper;
using CrudUsuario.Core.Exeptions;
using CrudUsuario.Domain.Entities;
using CrudUsuario.Infra.Interfaces;
using CrudUsuario.Services.DTOs;
using CrudUsuario.Services.Interfaces;

namespace CrudUsuario.Services.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    public async Task<UserDTO> Create(UserDTO userDTO)
    {
        var userExists = await _userRepository.GetByEmail(userDTO.Email);

        if (userExists != null)
        {
            throw new DomainExeption("Já existe um usuário com o email cadastrado");
        }
        
        var user = _mapper.Map<User>(userDTO);
        user.Validate();

        var userCreated = await _userRepository.Create(user);

        return _mapper.Map<UserDTO>(userDTO);
    }

    public async Task<List<GetUserDTO>> GetAll()
    {
        var allUsers = await _userRepository.GetAll();

        return _mapper.Map<List<GetUserDTO>>(allUsers);
    }

    public async Task<GetUserDTO> GetById(int id)
    {
        var userExists = await _userRepository.GetById(id);

        if (userExists == null)
        {
            throw new DomainExeption("Não existe um usuário com o Id informado");
        }

        return _mapper.Map<GetUserDTO>(userExists);
    }

    public async Task<GetUserDTO> GetByEmail(string email)
    {
        var userExists = await _userRepository.GetByEmail(email);

        if (userExists == null)
        {
            throw new DomainExeption("Não existe um usuário com o email informado");
        }

        return _mapper.Map<GetUserDTO>(userExists);
    }

    public async Task<GetUserDTO> GetByRg(string rg)
    {
        var userExists = await _userRepository.GetByRG(rg);

        if (userExists == null)
        {
            throw new DomainExeption("Não existe um usuário com o Rg informado");
        }

        return _mapper.Map<GetUserDTO>(userExists);
    }

    public async Task<GetUserDTO> GetByCPF(string cpf)
    {
        var userExists = await _userRepository.GetByCPF(cpf);

        if (userExists == null)
        {
            throw new DomainExeption("Não existe um usuário com o CPF informado");
        }

        return _mapper.Map<GetUserDTO>(userExists);
    }

    public async Task<UserDTO> Update(UserDTO userDTO)
    {
        var userExists = await _userRepository.Exists(userDTO.Email, userDTO.RG, userDTO.CPF);

        if (userExists == null)
        {
            throw new DomainExeption("Não existe um usuário com os valores informado");
        }
        
        var user = _mapper.Map<User>(userDTO);
        user.Validate();

        var userUpdated = await _userRepository.Update(user);

        return _mapper.Map<UserDTO>(userDTO);
    }

    public async Task Delete(int id)
    {
        await _userRepository.Delete(id);
    }
}