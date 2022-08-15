namespace WebApi.Helpers;

using System.Net;
using System.Text.Json;
using TesteBravi.ListaDeContatos.Exceptions;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case TipoDeContatoInvalidoException:
                case EmailInvalidoException:
                case TelefoneInvalidoException:
                case ContatoJaExistenteException:
                case NomeCurtoOuInexistenteException:
                    // Erros de Validação
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case PessoaNaoEncontradaException:
                case ContatoNaoEncontradoException:
                    // Não Encontrado
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // Erro Desconhecido
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}