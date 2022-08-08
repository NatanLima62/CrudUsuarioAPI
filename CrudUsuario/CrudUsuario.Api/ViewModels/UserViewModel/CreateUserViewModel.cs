using System.ComponentModel.DataAnnotations;

namespace CrudUsuario.Api.ViewModels.UserViewModel;

public class CreateUserViewModel
{
    [Required(ErrorMessage = "O nome do usuário não pode ser vazio")]
    [MinLength(3, ErrorMessage = "O nome do usuário deve ter no mínomo 3 caracteres")]
    [MaxLength(180, ErrorMessage = "O nome do usuário deve ter no maáximo 180 caracteres")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O Rg do usuário não pode ser vazio")]
    [MinLength(6, ErrorMessage = "O Rg do usuário deve ter no mínomo 6 caracteres")]
    [MaxLength(13, ErrorMessage = "O Rg do usuário deve ter no maáximo 13 caracteres")]
    public string RG { get; set; }
    
    [Required(ErrorMessage = "O CPF do usuário não pode ser vazio")]
    [MinLength(6, ErrorMessage = "O CPF do usuário deve ter no mínomo 6 caracteres")]
    [MaxLength(14, ErrorMessage = "O CPF do usuário deve ter no maáximo 14 caracteres")]
    public string CPF { get; set; }
    
    [Required(ErrorMessage = "O email do usuário não pode ser vazio")]
    [MinLength(11, ErrorMessage = "O email do usuário deve ter no minimo 11 caracteres")]
    [MaxLength(180, ErrorMessage = "O email do usuário deve ter no maximo 180 caracteres")]
    [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "O email do usuário deve ser válido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A senha do usuário não pode ser vazio")]
    [MinLength(8, ErrorMessage = "A senha do usuário deve ter no mínomo 8 caracteres")]
    [MaxLength(80, ErrorMessage = "A senha do usuário deve ter no maáximo 80 caracteres")]
    public string Password { get; set; }
}