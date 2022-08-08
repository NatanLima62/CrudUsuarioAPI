using CrudUsuario.Domain.Validators;

namespace CrudUsuario.Domain.Entities;

public class User : Base
{
    public string Name { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public override bool Validate()
    {
        var validator = new UserValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);
            }

            throw new Exception("Alguns campos estão inválidos por favor corrija-os");
        }

        return true;
    }
}