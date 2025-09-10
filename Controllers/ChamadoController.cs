using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServico.Models.Dtos;

namespace ApiServico.Controllers
{
    [Route("/chamados")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {

        private static List<Chamado> _ListaChamados = new List<Chamado>
        {
            new Chamado() {Id = 1, Titulo = "Erro na Tela de Acesso", Descricao = "O usuário não consegiu logar"},
            new Chamado() {Id = 2, Titulo = "Sistema com certidão", Descricao = "Demora no carregamento das telas"}
        };

        private static int _proximoId = 3;

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(_ListaChamados);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var chamado = _ListaChamados.FirstOrDefault(item => item.Id ==id);

            if (chamado == null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ChamadoDto novoChamado)
        {
            var chamado = new Chamado() { Titulo = novoChamado.Titulo, Descricao = novoChamado.Descricao };
            chamado.Id = _proximoId++;
            chamado.Status = "Aberto";

            _ListaChamados.Add(chamado);
            return Created("", chamado);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] ChamadoDto novoChamado)
        {
            var chamado = _ListaChamados.FirstOrDefault(item => item.Id == id);

            if(chamado == null)
            {
                return NotFound();
            }

            chamado.Titulo = novoChamado.Titulo;
            chamado.Descricao = novoChamado.Descricao;

            return Ok(chamado);
        }


        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var chamado = _ListaChamados.FirstOrDefault(item => item.Id == id);

            if (chamado == null)
            {
                return NotFound();
            }

            _ListaChamados.Remove(chamado);

            return NoContent();
        }

    }
}
