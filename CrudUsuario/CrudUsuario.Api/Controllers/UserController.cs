using AutoMapper;
using CrudUsuario.Api.Utilities;
using CrudUsuario.Api.ViewModels.ResultViewModel;
using CrudUsuario.Api.ViewModels.UserViewModel;
using CrudUsuario.Core.Exeptions;
using CrudUsuario.Services.DTOs;
using CrudUsuario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsuario.Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/api/v1/users/create")]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModel createUserViewModel)
    {
        try
        {
            var user = _mapper.Map<UserDTO>(createUserViewModel);

            var userCreated = await _userService.Create(user);

            return Ok(new ResultViewModel
            {
                Message = "Usuário criado com sucesso",
                Sucess = true,
                Data = userCreated
            });
        }
        catch (DomainExeption exeption)
        {
            return BadRequest(Responses.DomainErrorMessage(exeption.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Route("/api/v1/users/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allUsers = await _userService.GetAll();

            return Ok(new ResultViewModel
            {
                Message = "Usuários encontrados com sucesso",
                Sucess = true,
                Data = allUsers
            });
        }
        catch (DomainExeption exeption)
        {
            return BadRequest(Responses.DomainErrorMessage(exeption.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Route("/api/v1/users/GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var user = await _userService.GetById(id);

            if (user != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Sucess = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Não foi possivel encontrar um usuário com o id informado",
                Sucess = false,
                Data = null
            });
        }
        catch (DomainExeption exeption)
        {
            return BadRequest(Responses.DomainErrorMessage(exeption.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpGet]
    [Route("/api/v1/users/GetByEmail/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        try
        {
            var user = await _userService.GetByEmail(email);

            if (user != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Sucess = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Não foi possivel encontrar um usuário com o email informado",
                Sucess = false,
                Data = null
            });
        }
        catch (DomainExeption exeption)
        {
            return BadRequest(Responses.DomainErrorMessage(exeption.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpGet]
    [Route("/api/v1/users/GetByRg/{rg}")]
    public async Task<IActionResult> GetByRg(string rg)
    {
        try
        {
            var user = await _userService.GetByRg(rg);

            if (user != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Sucess = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Não foi possivel encontrar um usuário com o Rg informado",
                Sucess = false,
                Data = null
            });
        }
        catch (DomainExeption exeption)
        {
            return BadRequest(Responses.DomainErrorMessage(exeption.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    [HttpGet]
    [Route("/api/v1/users/GetByCPF/{cpf}")]
    public async Task<IActionResult> GetByCPF(string cpf)
    {
        try
        {
            var user = await _userService.GetByCPF(cpf);

            if (user != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Sucess = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Não foi possivel encontrar um usuário com o CPF informado",
                Sucess = false,
                Data = null
            });
        }
        catch (DomainExeption exeption)
        {
            return BadRequest(Responses.DomainErrorMessage(exeption.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpPut]
    [Route("/api/v1/users/Update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserViewModel updateUserViewModel)
    {
        try
        {
            var user = _mapper.Map<UserDTO>(updateUserViewModel);

            var userUpdated = await _userService.Update(user);

            return Ok(new ResultViewModel
            {
                Message = "Usuario atualizado com sucesso",
                Sucess = true,
                Data = userUpdated
            });
        }
        catch (DomainExeption exeption)
        {
            return BadRequest(Responses.DomainErrorMessage(exeption.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpDelete]
    [Route("/api/v1/users/Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _userService.Delete(id);

            return Ok(new ResultViewModel
            {
                Message = "Usuário deletado com sucesso",
                Sucess = true,
                Data = null
            });
        }
        catch (DomainExeption exeption)
        {
            return BadRequest(Responses.DomainErrorMessage(exeption.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
}