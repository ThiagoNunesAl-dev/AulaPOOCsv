namespace AulaPOOCsv
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string Path = "Database/Produto.csv";

        //Cria uma pasta Produto.csv (conforme o caminho criado acima), se esta não existir.
        public Produto () {
            if (!File.Exists(Path)) {
                File.Create(Path).Close();
            }
        }

        //Prepara uma linha no formato padrão csv.
        private string PrepararLinhaCSV (Produto p) {
            return $"Código:{p.Codigo};Nome:{p.Nome};Preço:{p.Preco}";
        }

        //Insere a linha criada e preenchida conforme o método acima no documento csv.
        //O formato suportado é de lista, então é necessário transformar a string preparada anteriormente em uma lista.
        public void Inserir (Produto p) {
            string[] linha = new string[] {PrepararLinhaCSV(p)};
            //Append acrescenta as linhas preparadas ao documento csv.
            File.AppendAllLines(Path, linha);
        }

        //Separa os dados.
        public string Separar (string dado) {
            //Ex.:
            //dado => Código:1
            //dado[0] => Código
            //dado[1] => 1
            //Retorna o número do código, sem o enunciado.
            return dado.Split(":")[1];
        }

        public List<Produto> Ler () {
            //Cria-se uma lista de produtos padrão.
            List<Produto> produtos = new List<Produto>();
            //Transforma-se as linhas criadas em um arranjo de strings.
            string[] linhas = File.ReadAllLines(Path);
            //O array é varrido.

            foreach (var linha in linhas)
            {
                //Os dados das linhas são separados.
                string[] dados = linha.Split(";");
                
                //Os dados agora são tratados para que possam ser colocados na lista.
                Produto prod = new Produto();
                prod.Codigo = Int32.Parse(Separar(dados[0]));
                prod.Nome = Separar(dados[1]);
                prod.Preco = float.Parse(Separar(dados[2]));

                //Os dados são inseridos na lista.
                produtos.Add(prod);
            }

            produtos = produtos.OrderBy(z => z.Nome).ToList();
            
            return produtos;
        }
    }
}