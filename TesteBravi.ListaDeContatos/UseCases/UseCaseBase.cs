using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class UseCaseBase
    {
        protected ActionResult NotFound() => new NotFoundResult();
        protected BadRequestResult BadRequest() => new BadRequestResult();
        protected NoContentResult NoContent() => new NoContentResult();
        protected CreatedResult Created(string? location, object? value) => new CreatedResult(location, value);
    }
}
