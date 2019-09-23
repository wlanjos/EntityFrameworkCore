using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Produto() { Nome = "Suco de laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Cafe", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrao", Categoria = "Alimentos", PrecoUnitario = 4.25, Unidade = "Gramas" };


            var promocaoDePacoa = new Promocao();
            promocaoDePacoa.Descricao = "Pascoa feliz";
            promocaoDePacoa.DataInicio = DateTime.Now;
            promocaoDePacoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePacoa.IncluirProduto(p1);
            promocaoDePacoa.IncluirProduto(p2);
            promocaoDePacoa.IncluirProduto(p3);

            var paoFrances = new Produto()
            {
                Nome = "Pão Frances",
                PrecoUnitario = 0.40,
                Unidade = "Unidade",
                Categoria = "Padaria"

            };
            //var compra = new Compra();
            //compra.Quantidade = 6;
            //compra.Produto = paoFrances;
            //compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {



                //contexto.Produtos.Add(promocaoDePacoa);
                var promocao = contexto.Promocoes.Find(3);
                contexto.Promocoes.Remove(promocao);


                contexto.SaveChanges();
            }
        }

    }
}

;