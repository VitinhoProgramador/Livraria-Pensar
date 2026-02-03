import { useEffect, useState } from "react";
import { listarLivros } from "../services/livroService";
import type { Livro } from "../types/Livro";

export function Livros() {
  const [livros, setLivros] = useState<Livro[]>([]);

  useEffect(() => {
    listarLivros().then(response => {
      if (response.status) {
        setLivros(response.dados);
      }
    });
  }, []);

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Livros</h1>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        {livros.map(livro => (
          <div
            key={livro.idLivro}
            className="border rounded-lg p-4 shadow"
          >
            <h2 className="font-semibold">{livro.titulo}</h2>
            <p className="text-sm text-gray-600">
              ISBN: {livro.isbn}
            </p>
            <p className="text-sm">
              Ano: {livro.anoPublicacao}
            </p>
          </div>
        ))}
      </div>
    </div>
  );
}
