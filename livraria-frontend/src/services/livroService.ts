import { api } from "../api/axios";
import type{ Livro } from "../types/Livro";
import type { ResponseModel } from "../types/ResponseModel";

// GET - Listar livros
export async function listarLivros() {
  const response = await api.get<ResponseModel<Livro[]>>(
    "/Livro/ListarLivros"
  );
  return response.data;
}

// GET - Buscar livro por ID
export async function buscarLivroPorId(idLivro: number) {
  const response = await api.get<ResponseModel<Livro>>(
    `/Livro/BuscarLivroPorId/${idLivro}`
  );
  return response.data;
}

// GET - Buscar livro por ID do autor
export async function buscarLivroPorIdAutor(idAutor: number) {
  const response = await api.get<ResponseModel<Livro>>(
    `/Livro/BuscarLivroPorIdAutor/${idAutor}`
  );
  return response.data;
}

// POST - Criar livro
export async function criarLivro(livro: {
  titulo: string;
  isbn: string;
  anoPublicacao: number;
  autorId: number;
}) {
  const response = await api.post<ResponseModel<Livro>>(
    "/Livro/CriarLivro",
    livro
  );
  return response.data;
}

// PUT - Editar livro
export async function editarLivro(livro: {
  idLivro: number;
  titulo: string;
  isbn: string;
  anoPublicacao: number;
  autorId: number;
}) {
  const response = await api.put<ResponseModel<Livro>>(
    "/Livro/EditarLivro",
    livro
  );
  return response.data;
}

// DELETE - Excluir livro
export async function excluirLivro(idLivro: number) {
  const response = await api.delete<ResponseModel<Livro>>(
    "/Livro/ExcluirLivro",
    { params: { idLivro } }
  );
  return response.data;
}
