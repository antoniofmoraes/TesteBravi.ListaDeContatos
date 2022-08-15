using Microsoft.AspNetCore.Mvc;

namespace TesteBravi.ListaDeContatos.Controllers
{
    public class ErroDesconhecidoResult : JsonResult
    {
        public ErroDesconhecidoResult(Exception ex) : base(new
            {
                title = ex.Message,
                status = 400,
                details = "Erro desconhecido"
            })
        {

        }
    }
}
