namespace CrudUsuario.Core.Exeptions;

public class DomainExeption : Exception
{
    internal List<string> _errors;
    
    public DomainExeption()
    {
        
    }

    public DomainExeption(string message, List<string> errors) : base(message)
    {
        _errors = errors;
    }

    public DomainExeption(string message) : base(message)
    {
        
    }

    public DomainExeption(string message, Exception innerException) : base(message, innerException)
    {

    }
}