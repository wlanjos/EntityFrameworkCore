using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var paoFrances = new Produto()
            {
                Nome = "Pão Frances",
                PrecoUnitario = 0.40,
                Unidade = "Unidade",
                Categoria = "Padaria"

            };
            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {

                contexto.Compras.Add(compra);
                contexto.SaveChanges();
            }

        }

    }
}

