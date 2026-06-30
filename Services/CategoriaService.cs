using CategoriaMicroservice.Models;

namespace CategoriaMicroservice.Services
{
    public class CategoriaService
    {
        private readonly List<Categoria> categorias = new()
        {
            new Categoria { Id = 1, Nombre = "Tecnologia", Activa = true},
            new Categoria { Id = 2, Nombre = "Hogar", Activa = false},
            new Categoria { Id = 3, Nombre = "Limpieza", Activa = false},
            new Categoria { Id = 4, Nombre = "Industria", Activa = true},
            new Categoria { Id = 5, Nombre = "Farmacia", Activa = true}
        };

        public List<Categoria> ObtenerTodas()
        {
            return categorias;
        }

        public Categoria? ObtenerPorId(int id)
        {
            return categorias.FirstOrDefault(c => c.Id == id);
        }

        public Categoria Agregar(Categoria nuevaCategoria)
        {
            nuevaCategoria.Id = categorias.Count + 1;
            categorias.Add(nuevaCategoria);
            return nuevaCategoria;
        }
    }
}