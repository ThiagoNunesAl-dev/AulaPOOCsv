namespace AulaPOOCsv
{
    using System.Collections.Generic;
    public interface IProduto
    {
        string PrepararLinhaCSV (Produto p);
        void Inserir (Produto p);
        string Separar (string dado);
        List<Produto> Ler ();
        void Remover (string _termo);
        void AlterarProduto (Produto produtoAlterado);
    }
}