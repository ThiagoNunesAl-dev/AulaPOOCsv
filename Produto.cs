namespace AulaPOOCsv
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string Path = "Database/Produto.csv";

        public Produto () {
            if (!File.Exists(Path)) {
                File.Create(Path).Close();
            }
        }
        private string PrepararLinhaCSV (Produto p) {
            return $"{p.Codigo};{p.Nome};{p.Preco}";
        }
        public void Inserir (Produto p) {
            string[] linha = new string[] {PrepararLinhaCSV(p)};
            File.AppendAllLines(Path, linha);
        }
    }
}