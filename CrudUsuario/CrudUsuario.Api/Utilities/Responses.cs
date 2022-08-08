using CrudUsuario.Api.ViewModels.ResultViewModel;

namespace CrudUsuario.Api.Utilities;

public class Responses
{
    public static ResultViewModel ApplicationErrorMessage()
    {
        return new ResultViewModel
        {
            Message = "Ocorreu algum erro interno na aplicação, por favor corrija-os",
            Sucess = false,
            Data = null
        };
    }

    public static ResultViewModel DomainErrorMessage(string message)
    {
        return new ResultViewModel
        {
            Message = message,
            Sucess = false,
            Data = null
        };
    }

    public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
        return new ResultViewModel
        {
            Message = message,
            Sucess = false,
            Data = null
        };
    }
}