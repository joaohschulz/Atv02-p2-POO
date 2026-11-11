using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Models;

namespace MinhaBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaisController : ControllerBase
    {
        private IMaterialRepository _repository;

        public MateriaisController(IMaterialRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]

        public IActionResult Get()
        {
            var resultado = _repository.ObterTodos().Select(material =>
            {
               
               return new
                {
                    material.Id,
                    material.Titulo,
                    material.AnoPublicacao,
                    Prazo = material.CalcularPrazo(),
                    Descricao = material.Descricao()

                };
            });
            return Ok(resultado);
        }

        [HttpGet("{id}")]

        public IActionResult GetPorId(int id)
        {
            var material = _repository.ObterPorId(id);

            if (material == null)
            {
                return NotFound();
            }

            if (material is Livro livro)
            {
                return Ok(new
                {
                    Tipo = "Livro",
                    livro.Id,
                    livro.Titulo,
                    livro.Autor,
                    livro.AnoPublicacao,
                    livro.Paginas,
                    Prazo = livro.CalcularPrazo(),
                    Descricao = livro.Descricao()
                });
            };
            if (material is Revista revista)
            {
                return Ok(new
                {
                    Tipo = "Revista",
                    revista.Id,
                    revista.Titulo,
                    revista.AnoPublicacao,
                    revista.Edicao,
                    revista.MesPublicacao,
                    Prazo = revista.CalcularPrazo(),
                    Descricao = revista.Descricao()
                });
            };
            return Ok(material);
        }

        [HttpPost("livro/")]

        public IActionResult PostLivro([FromBody] Livro livro)
        {
           var criado = _repository.Adicionar(livro);
           return CreatedAtAction(nameof(GetPorId), new {id = criado.Id}, criado);
        }

        [HttpPost("revista/")]
        public IActionResult PostRevista([FromBody] Revista revista)
        {
            var criado = _repository.Adicionar(revista);
            return CreatedAtAction(nameof(GetPorId), new {id = criado.Id}, criado);
        }

        [HttpPut("livro/{id}")]
        public IActionResult PutLivro(int id, [FromBody] Livro livro)
        {
            bool atualizou = _repository.Atualizar(id, livro);
            if (!atualizou)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("revista/{id}")]
        public IActionResult PutRevista(int id, [FromBody] Revista revista)
        {
            bool atualizou = _repository.Atualizar(id,revista);
            if (!atualizou)
            {
                return NotFound();
            }
            return NoContent();
        }


    

    }
}