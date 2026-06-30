using Microsoft.AspNetCore.Mvc;
using CategoriaMicroservice.Models;
using CategoriaMicroservice.Services;

namespace CategoriaMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoriaService.ObtenerTodas());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categoria = _categoriaService.ObtenerPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria nuevaCategoria)
        {
            if (string.IsNullOrWhiteSpace(nuevaCategoria.Nombre))
            {
                return BadRequest("El nombre de la categoria es obligatorio!");
            }
            var categoriaCreada = _categoriaService.Agregar(nuevaCategoria);
            return Created("", categoriaCreada);
        }
    }
}