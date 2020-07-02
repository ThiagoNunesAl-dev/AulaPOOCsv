using System;
using System.IO;
using System.Collections.Generic;

namespace AulaPOOCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Gibson SG";
            p1.Preco = 4700f;
            p1.Inserir(p1);

            Produto p2 = new Produto();
            p2.Codigo = 2;
            p2.Nome = "Ibanez RG440V";
            p2.Preco = 5000f;
            p2.Inserir(p2);

            p2.Remover("Gibson");

            Produto alterado = new Produto();
            alterado.Codigo = 1;
            alterado.Nome = "Fender Stratocaster";
            alterado.Preco = 7000f;
            
            p1.AlterarProduto(alterado);

            List<Produto> lista = new List<Produto>();
            lista = p1.Ler();

            foreach (Produto item in lista)
            {
                Console.WriteLine($"{item.Nome} - R$ {item.Preco}");
            }
        }
    }
}
