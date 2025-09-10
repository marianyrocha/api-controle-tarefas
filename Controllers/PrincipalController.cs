using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServico.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Principal()
        {
            var resultado = new { situacao = "Ok", mensagem = "Api Serviço" };
            return Ok(resultado);
        }

       [HttpGet("autor")]
        public IActionResult GetAutor()
        {
            var resultado = new { nome = "mariany", email = "marianyptn@gmail.com", telefone = "6992641541" };
            return Ok(resultado);
        }

        
    }

    
}
