using CrudUsuario.Domain.Entities;
using FluentValidation;

namespace CrudUsuario.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user)
            .NotEmpty()
            .WithMessage("O usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O usuário não pode ser nulo");

        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("O nome do usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O nome do usuário não pode ser nulo")

            .MinimumLength(3)
            .WithMessage("O nome do usuário deve ter no mínimo 3 caracteres")

            .MaximumLength(180)
            .WithMessage("O nome do usuário deve ter no máximo 180 caracteres");
        
        RuleFor(user => user.RG)
            .NotEmpty()
            .WithMessage("O RG do usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O RG do usuário não pode ser nulo")

            .MinimumLength(6)
            .WithMessage("O RG do usuário deve ter no mínimo 6 caracteres")

            .MaximumLength(13)
            .WithMessage("O RG do usuário deve ter no máximo 13 caracteres");
        
        RuleFor(user => user.CPF)
            .NotEmpty()
            .WithMessage("O CPF do usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O CPF do usuário não pode ser nulo")

            .MinimumLength(6)
            .WithMessage("O CPF do usuário deve ter no mínimo 6 caracteres")

            .MaximumLength(14)
            .WithMessage("O CPF do usuário deve ter no máximo 14 caracteres");
        
        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("A senha do usuário não pode ser vazio")

            .NotNull()
            .WithMessage("A senha do usuário não pode ser nulo")

            .MinimumLength(8)
            .WithMessage("A senha do usuário deve ter no mínimo 8 caracteres")

            .MaximumLength(30)
            .WithMessage("A senha do usuário deve ter no máximo 30 caracteres");
        
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("O email do usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O email do usuário não pode ser nulo")

            .MinimumLength(13)
            .WithMessage("O email do usuário deve ter no mínimo 13 caracteres")

            .MaximumLength(180)
            .WithMessage("O email do usuário deve ter no máximo 180 caracteres")
            
            .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            .WithMessage("O email do usuario deve ser válido");
    }
}