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
        throw new NotImplementedException();
    }
}