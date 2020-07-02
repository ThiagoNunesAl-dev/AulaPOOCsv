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

        //Exibir a lista no terminal.
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

            //Ordena a lista de acordo com o código.
            produtos = produtos.OrderBy(z => z.Codigo).ToList();
            
            return produtos;
        }

        //Remove itens da lista de produtos (arquivo csv), conforme um parâmetro específico.
        public void Remover (string _termo) {
            //Cria-se uma lista de itens para servir como backup.
            List<string> lines = new List<string>();

            //O arquivo é aberto e lido.
            using(StreamReader file = new StreamReader (Path)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    lines.Add(line);
                }
                //São removidos os itens que contêm o termo indicado.
                lines.RemoveAll(l => l.Contains(_termo));
            }
            //O arquivo agora é reescrito, sem o item removido.
            using (StreamWriter output = new StreamWriter(Path)) {
                output.Write(String.Join(Environment.NewLine, lines.ToArray()));
            }
        }

        public void AlterarProduto (Produto produtoAlterado) {
             //Cria-se uma lista de itens para servir como backup.
            List<string> lines = new List<string>();

            //O arquivo é aberto e lido.
            using(StreamReader file = new StreamReader (Path)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    lines.Add(line);
                }
                //A linha é removida de acordo com o código do produto.
                lines.RemoveAll(x => x.Split(";")[0].Contains(produtoAlterado.Codigo.ToString()));

                //A nova linha é adicionada.
                lines.Add(PrepararLinhaCSV(produtoAlterado));
            }

            //O arquivo é reescrito, agora com o novo item.
             using (StreamWriter output = new StreamWriter(Path)) {
                output.Write(String.Join(Environment.NewLine, lines.ToArray()));
            }
        }
    }
}