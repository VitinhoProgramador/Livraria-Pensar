import {api} from "../api/axios";
import type { Autor } from "../types/Autor";
import type { ResponseModel } from "../types/ResponseModel";

//get - listar autores
export async function listarAutores(){
    const response = await api.get<ResponseModel<Autor[]>>(
        "/Autor/ListarAutores"
    );
    return response.data;
}

//get - buscar autor por id
export async function buscarAutorPorId(idAutor: number) {
  const response = await api.get<ResponseModel<Autor>>(
    `/Autor/BuscarAutorPorId/${idAutor}`
  );
  return response.data;
}

// GET - Buscar autor por ID do livro
export async function buscarAutorPorIdLivro(idLivro: number) {
  const response = await api.get<ResponseModel<Autor>>(
    `/Autor/BuscarAutorPorIdLivro/${idLivro}`
  );
  return response.data;
}

// POST - Criar autor
export async function criarAutor(nome: string) {
  const response = await api.post<ResponseModel<Autor>>(
    "/Autor/CriarAutor",
    { nome }
  );
  return response.data;
}

// PUT - Editar autor
export async function editarAutor(idAutor: number, nome: string) {
  const response = await api.put<ResponseModel<Autor>>(
    "/Autor/EditarAutor",
    { idAutor, nome }
  );
  return response.data;
}

// DELETE - Excluir autor
export async function excluirAutor(idAutor: number) {
  const response = await api.delete<ResponseModel<Autor>>(
    "/Autor/ExcluirAutor",
    { params: { idAutor } }
  );
  return response.data;
}