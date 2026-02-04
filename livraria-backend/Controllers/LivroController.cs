using Livraria.Dto.Autor;
using Livraria.Dto.Livro;
using Livraria.Models;
using Livraria.Services.Autor;
using Livraria.Services.Livro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LivroController : ControllerBase
	{
		private readonly ILivroInterface _livroInterface;
		public LivroController(ILivroInterface livroInterface)
		{
			_livroInterface = livroInterface;
		}

		[HttpGet("ListarLivros")]

		public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
		{
			var livros = await _livroInterface.ListarLivros();
			return Ok(livros);
		}

		[HttpGet("BuscarLivroPorId/{idLivro}")]

		public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
		{
			var livro = await _livroInterface.BuscarLivroPorId(idLivro);
			return Ok(livro);
		}

		[HttpGet("BuscarLivroPorIdAutor/{idAutor}")]

		public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
		{
			var livro = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
			return Ok(livro);
		}

		[HttpPost("CriarLivro")]
		public async Task<ActionResult<ResponseModel<LivroModel>>> CriarLivro(LivroDto livroDto)
		{
			var livros = await _livroInterface.CriarLivro(livroDto);
			return Ok(livros);


		}

		[HttpPut("EditarLivro")]

		public async Task<ActionResult<ResponseModel<LivroModel>>> EditarLivro(LivroEditarDto livroEditarDto)
		{
			var livros = await _livroInterface.EditarLivro(livroEditarDto);
			return Ok(livros);
		}

		[HttpDelete("ExcluirLivro")]
		public async Task<ActionResult<ResponseModel<LivroModel>>> ExcluirLivro(int idLivro)
		{
			var livros = await _livroInterface.ExcluirLivro(idLivro);
			return Ok(livros);
		}


	}
}
