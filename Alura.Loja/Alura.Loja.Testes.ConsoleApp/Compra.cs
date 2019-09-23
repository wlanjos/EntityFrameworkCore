namespace Alura.Loja.Testes.ConsoleApp
{
    public  class Compra
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Promocao Produto { get; internal set; }
        public int Quantidade { get; internal set; }
        public double Preco { get; internal set; }
    }
}