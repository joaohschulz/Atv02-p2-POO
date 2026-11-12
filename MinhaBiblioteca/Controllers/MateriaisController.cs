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
                    Tipo = material.GetType().Name,
                    material.Titulo,
                    material.AnoPublicacao,
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
            ;
            return Ok(material);
        }

        [HttpPost("livro/")]

        public IActionResult PostLivro([FromBody] Livro livro)
        {
            if (string.IsNullOrWhiteSpace(livro.Titulo))
            {
                return BadRequest("O titulo é obrigatório");
            }
            if (livro.AnoPublicacao < 0)
            {
                return BadRequest("O ano de publicação não pode ser menor que 0");
            }
            if (string.IsNullOrWhiteSpace(livro.Autor))
            {
                return BadRequest("O autor é obrigatório");
            }
            if (livro.Paginas <= 0)
            {
                return BadRequest("O número de páginas não podem ser menor ou igual a 0");
            }


            var criado = _repository.Adicionar(livro);
            return CreatedAtAction(nameof(GetPorId), new { id = criado.Id }, criado);
        }

        [HttpPost("revista/")]
        public IActionResult PostRevista([FromBody] Revista revista)

        {
            if (string.IsNullOrWhiteSpace(revista.Titulo))
            {
                return BadRequest("O titulo é obrigatório");
            }
            if (revista.AnoPublicacao < 0)
            {
                return BadRequest("O ano de publicação não pode ser menor que 0");
            }
            if (revista.Edicao <= 0)
            {
                return BadRequest("A edição da revista não pode ser menor que 0");
            }
            if (revista.MesPublicacao < 1 || revista.MesPublicacao > 12)
            {
                return BadRequest("O mês deve estar entre os números 1 e 12");
            }

            var criado = _repository.Adicionar(revista);
            return CreatedAtAction(nameof(GetPorId), new { id = criado.Id }, criado);
        }

        [HttpPut("livro/{id}")]
        public IActionResult PutLivro(int id, [FromBody] Livro livro)
        {
            if (string.IsNullOrWhiteSpace(livro.Titulo))
            {
                return BadRequest("O titulo é obrigatório");
            }
            if (livro.AnoPublicacao < 0)
            {
                return BadRequest("O ano de publicação não pode ser menor que 0");
            }
            if (string.IsNullOrWhiteSpace(livro.Autor))
            {
                return BadRequest("O autor é obrigatório");
            }
            if (livro.Paginas <= 0)
            {
                return BadRequest("O número de páginas não podem ser menor ou igual a 0");
            }

            bool atualizou = _repository.Atualizar(id, livro);
            if (!atualizou)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPut("revista/{id}")]
        public IActionResult PutRevista(int id, [FromBody] Revista revista)
        {
            if (string.IsNullOrWhiteSpace(revista.Titulo))
            {
                return BadRequest("O titulo é obrigatório");
            }
            if (revista.AnoPublicacao < 0)
            {
                return BadRequest("O ano de publicação não pode ser menor que 0");
            }
            if (revista.Edicao <= 0)
            {
                return BadRequest("A edição da revista não pode ser menor que 0");
            }
            if (revista.MesPublicacao < 1 || revista.MesPublicacao > 12)
            {
                return BadRequest("O mês deve estar entre os números 1 e 12");
            }

            bool atualizou = _repository.Atualizar(id, revista);
            if (!atualizou)
            {
                return NotFound();
            }
            return Ok(revista);
        }

        [HttpDelete("{id}")]


        public IActionResult DeleteMaterial(int id)
        {
            bool removido = _repository.Remover(id);
            if (!removido)
            {
                return NotFound("Material não encontrado.");
            }
            return NoContent();

        }

        [HttpGet("{id}/descricao")]

        public IActionResult GetMaterial(int id)
        {
            var material = _repository.ObterPorId(id);
            if (material is null)
            {
                return NotFound("Materila não encontrado");
            }
            return Ok(new
            {
                material.Id,
                Tipo = material.GetType().Name,
                Descricao = material.Descricao(),
                Prazo = material.CalcularPrazo()
            });
        }


        [HttpPost("{id}/emprestar")]

        public IActionResult PostEmprestar(int id)
        {

            var material = _repository.ObterPorId(id);
            if (material is null)
            {
                return NotFound("Material não encontrado");
            }
            if (material is not IEmprestimo emprestavel)
            {
                return BadRequest($"O material: {material.Titulo} não pode ser emprestado");
            }

            return Ok(new
            {
                Mensagem = emprestavel.Emprestar()
            });


        }
    }
}