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
        }
    }
}
