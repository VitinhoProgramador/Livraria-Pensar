import type {Autor} from "./Autor"


export interface Livro {
  id: number;
  titulo: string;
  descricao?: string;
  preco: number;
  imagemCapa?: string; // URL da imagem
  autor: Autor; // O autor vem aninhado ou apenas o AutorId
  estoque: number;
}