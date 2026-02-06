import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom"; // Importar hook de busca
import { BookCard } from "../components/BookCard";
import type { Livro } from "../types/Livro";
import { listarLivros } from "../services/livroService";
import { Loader2, BookX } from "lucide-react";

export function Home() {
  const [searchParams] = useSearchParams();
  const [livros, setLivros] = useState<Livro[]>([]);
  const [loading, setLoading] = useState(true);
  const [erro, setErro] = useState("");

  // Captura o termo de busca da URL
  const buscaTermo = searchParams.get("busca")?.toLowerCase() || "";

  useEffect(() => {
    carregarLivros();
  }, []);

  async function carregarLivros() {
    try {
      setLoading(true);
      const resposta = await listarLivros();
      if (resposta.status) {
        setLivros(resposta.dados);
      } else {
        setErro(resposta.mensagem);
      }
    } catch (error) {
      setErro("Não foi possível carregar os livros.");
    } finally {
      setLoading(false);
    }
  }

  // 🔍 Lógica de Filtragem
  const livrosFiltrados = livros.filter(livro => {
    const porTitulo = livro.titulo.toLowerCase().includes(buscaTermo);
    const porAutor = livro.autor?.nome.toLowerCase().includes(buscaTermo) || 
                     livro.autor?.sobrenome.toLowerCase().includes(buscaTermo);
    return porTitulo || porAutor;
  });

  return (
    <div className="min-h-screen bg-slate-50">
      <main className="max-w-7xl mx-auto px-4 py-8">
        
        {/* Cabeçalho Dinâmico */}
        <div className="flex items-center justify-between mb-8">
          <div>
            <h2 className="text-2xl font-bold text-slate-800 border-l-4 border-blue-600 pl-4">
              {buscaTermo ? `Resultados para "${buscaTermo}"` : "Catálogo Completo"}
            </h2>
            {buscaTermo && (
              <p className="text-sm text-slate-500 mt-1 ml-5">
                Mostrando {livrosFiltrados.length} de {livros.length} livros
              </p>
            )}
          </div>
        </div>

        {/* Estados de Carregamento e Erro */}
        {loading && (
          <div className="flex flex-col items-center justify-center py-20 text-slate-500">
            <Loader2 className="w-12 h-12 text-blue-600 animate-spin mb-4" />
            <p>Buscando livros...</p>
          </div>
        )}

        {/* Busca sem resultados */}
        {!loading && livrosFiltrados.length === 0 && (
          <div className="text-center py-20 bg-white rounded-2xl border border-dashed border-slate-300">
            <BookX className="w-16 h-16 text-slate-300 mx-auto mb-4" />
            <h3 className="text-lg font-semibold text-slate-700">Ops! Nada encontrado</h3>
            <p className="text-slate-500">Tente buscar por outro título ou autor.</p>
            {buscaTermo && (
              <button 
                onClick={() => window.location.href = "/"}
                className="mt-4 text-blue-600 font-bold hover:underline"
              >
                Limpar busca
              </button>
            )}
          </div>
        )}

        {/* Grid de Resultados */}
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
          {livrosFiltrados.map((livro) => (
            <BookCard key={livro.id} livro={livro} />
          ))}
        </div>

      </main>
    </div>
  );
}