import { useEffect, useState } from "react";
import { listarAutores } from "../services/autorService";
import { listarLivros } from "../services/livroService";
import { Link } from "react-router-dom";

export function Home() {
  const [totalAutores, setTotalAutores] = useState(0);
  const [totalLivros, setTotalLivros] = useState(0);

  useEffect(() => {
    listarAutores().then(res => {
      if (res.status) {
        setTotalAutores(res.dados.length);
      }
    });

    listarLivros().then(res => {
      if (res.status) {
        setTotalLivros(res.dados.length);
      }
    });
  }, []);

  return (
    <div className="p-6 space-y-8">
      
      {/* Header */}
      <div>
        <h1 className="text-3xl font-bold">
          📚 Sistema de Livraria
        </h1>
        <p className="text-gray-600">
          Gerencie autores e livros de forma simples
        </p>
      </div>

      {/* Cards resumo */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        
        <div className="bg-white border rounded-xl p-6 shadow">
          <h2 className="text-lg font-semibold">Autores</h2>
          <p className="text-4xl font-bold mt-2">
            {totalAutores}
          </p>
          <p className="text-gray-500 text-sm">
            autores cadastrados
          </p>
        </div>

        <div className="bg-white border rounded-xl p-6 shadow">
          <h2 className="text-lg font-semibold">Livros</h2>
          <p className="text-4xl font-bold mt-2">
            {totalLivros}
          </p>
          <p className="text-gray-500 text-sm">
            livros cadastrados
          </p>
        </div>

      </div>

      {/* Ações rápidas */}
      <div className="flex gap-4">
        <Link
          to="/livros"
          className="bg-blue-600 text-white px-6 py-3 rounded-lg hover:bg-blue-700 transition"
        >
          📘 Ver Livros
        </Link>

        <Link
          to="/autores"
          className="bg-green-600 text-white px-6 py-3 rounded-lg hover:bg-green-700 transition"
        >
          👤 Ver Autores
        </Link>
      </div>

    </div>
  );
}
