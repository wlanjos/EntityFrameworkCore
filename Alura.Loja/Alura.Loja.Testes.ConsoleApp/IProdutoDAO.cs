using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    interface IProdutoDAO
    {
        void Adicionar(Promocao p);
        void Atualizar(Promocao p);
        void Remover(Promocao p);
        IList<Promocao> Produtos();
    }
}
