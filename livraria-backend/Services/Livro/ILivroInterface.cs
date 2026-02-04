using Livraria.Dto.Livro;
using Livraria.Models;

namespace Livraria.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idLivro);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDto livroDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEditarDto livroEditarDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);

    }
}
