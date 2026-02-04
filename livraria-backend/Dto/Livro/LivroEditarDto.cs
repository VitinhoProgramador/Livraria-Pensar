using Livraria.Models;

namespace Livraria.Dto.Livro
{
    public class LivroEditarDto
    {
		public int Id { get; set; }
		public string Titulo { get; set; }
		public AutorModel Autor { get; set; }
	}
}
