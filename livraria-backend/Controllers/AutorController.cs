using Livraria.Dto.Autor;
using Livraria.Models;
using Livraria.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]

        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores(); 
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
		public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorDto autorDto)
		{
            var autores = await _autorInterface.CriarAutor(autorDto);
            return Ok(autores);

			
		}

        [HttpPut("EditarAutor")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEditarDto autorEditarDto)
        {
            var autores = await _autorInterface.EditarAutor(autorEditarDto);
            return Ok(autores);
        }

        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(idAutor);
            return Ok(autores);
        }


	}
}
