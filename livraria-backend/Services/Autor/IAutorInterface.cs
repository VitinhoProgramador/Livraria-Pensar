using Livraria.Dto.Autor;
using Livraria.Models;

namespace Livraria.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDto autorDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEditarDto autorEditarDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);
    }
}
