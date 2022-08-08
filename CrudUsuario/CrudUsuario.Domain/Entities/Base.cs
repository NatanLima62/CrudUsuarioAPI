namespace CrudUsuario.Domain.Entities;

public abstract class Base
{
    public int Id { get; set; }
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }

    internal List<string> _errors;
    public virtual IReadOnlyCollection<string> Error => _errors;

    public abstract bool Validate();
}