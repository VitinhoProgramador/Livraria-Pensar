using System.Collections.Generic;
using Livraria.Data;
using Livraria.Dto.Autor;
using Livraria.Dto.Livro;
using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if(livro == null)
                {
                    resposta.Mensagem = "Nenhum livro encontrado!";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro encontrado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }

        }

        public async Task <ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
			ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
			try
			{
				var livro = await _context.Livros.Include(a => a.Autor).Where(livroBanco => livroBanco.Autor.Id == idAutor).ToListAsync();

				if (livro == null)
				{
					resposta.Mensagem = "Nenhum registro encontrado";
					return resposta;
				}
                resposta.Dados = livro;
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

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDto livroDto)
        {
			ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

			try
			{
                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroDto.Autor.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor localizado!";
                    return resposta;
                }
                var livro = new LivroModel()
                {
                    Titulo = livroDto.Titulo,
                    Autor = autor,
                };
                _context.Add(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                return resposta;
			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEditarDto livroEditarDto)
        {
			ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
			try
			{
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEditarDto.Id);

                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEditarDto.Autor.Id);

				if (autor == null)
				{
					resposta.Mensagem = "Nenhum registro de autor localizado!";
					return resposta;
				}
				if (livro == null)
				{
					resposta.Mensagem = "Nenhum registro de livro localizado!";
					return resposta;
				}
				livro.Titulo = livroEditarDto.Titulo;
				livro.Autor = autor;

				_context.Update(livro);
				await _context.SaveChangesAsync();

				resposta.Dados = await _context.Livros.ToListAsync();
				return resposta;


			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
			ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

			try
			{
				var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

				if (livro == null)
				{
					resposta.Mensagem = "Nenhum livro localizado!";
					return resposta;
				}
				_context.Remove(livro);
				await _context.SaveChangesAsync();

				resposta.Dados = await _context.Livros.ToListAsync();
				resposta.Mensagem = "Livro removido com sucesso!";
				return resposta;

			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
			ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
			try
			{
                var livros = await _context.Livros.ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Aqui estão todos os livros!";
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
