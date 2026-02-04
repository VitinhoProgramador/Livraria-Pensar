using Livraria.Data;
using Livraria.Dto.Autor;
using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Services.Autor
{
    public class AutorService: IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
			ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

			try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado!";
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
			ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

			try
			{
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if(livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor Localizado!";
                return resposta;



			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;
			}
		}

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDto autorDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Nome = autorDto.Nome,
                    Sobrenome = autorDto.Sobrenome,
                };
                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso!";

                return resposta;
            }
            catch (Exception ex) 
            {
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}

		}

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEditarDto autorEditarDto)
        {
			ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

			try
			{
                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEditarDto.Id);
                if( autor == null)
                {
                    resposta.Mensagem = "Nenhum autor encontrado!";
                    return resposta;
                }
                autor.Nome = autorEditarDto.Nome;
                autor.Sobrenome = autorEditarDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso";
                return resposta;
			
			
			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado!";
                    return resposta;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Autor removido com sucesso!";
                return resposta;

            }
            catch(Exception ex)
            {
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}

		}

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autor.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Aqui estão todos os autores";
                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;



            }
        }
    }
}
