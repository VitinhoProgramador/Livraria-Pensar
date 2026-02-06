namespace Livraria.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao {get; set;}
        public decimal Preco {get; set;}
        public string? imagemCapa { get; set;}
        public int Estoque {get; set;}

        public AutorModel Autor { get; set; }
    }
}
