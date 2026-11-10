using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Models;

namespace MinhaBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaisController : ControllerBase
    {
        private static Dictionary<int, MaterialBiblioteca> _materiais = new Dictionary<int, MaterialBiblioteca>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_materiais.Values);
        }
    }
}