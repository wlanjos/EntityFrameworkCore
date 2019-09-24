
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();
                Console.WriteLine($"Endereco de entrega: {cliente.EnderecoDeEntrega.Logradouro}" );

                var produto = contexto
                    .Produtos 
                    .Include(p => p.Compras)
                    .Where(p => p.Id == 3002)
                    .FirstOrDefault();

                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 10)
                    .Load();

                Console.WriteLine($"Mostrando as compras do produto : {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }
            }

        }

        private static void ExbibeProdutosDaPromocao()
        {
            using (var contexto2 = new LojaContext())
            {
                var serviceProvider = contexto2.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = contexto2
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();
                Console.WriteLine("\nMotrando os produtos da promoção...");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluirPromocao()
        {   
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Janeiro 2019";
                promocao.DataInicio = new DateTime(2019, 1, 1);
                promocao.DataTermino = new DateTime(2019, 1, 31);


                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                foreach (var item in produtos)
                {
                    promocao.IncluirProduto(item);
                }

                contexto.Promocoes.Add(promocao);
                ExibeEntries(contexto.ChangeTracker.Entries());
                contexto.SaveChanges();
            }
        }

        private static void UmPraUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho da Silva";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Invalidos",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Cidades"
            };

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
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

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }

    }
}

;