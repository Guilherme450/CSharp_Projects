namespace Biblioteca
{
    public class Livro
    {
        // classe Livro armazena as principais caracteristicas de um livro
        public string Titulo {get; set;}
        public string NomeAutor {get; set;}
        public int QuantidadePagina {get; set;}
        public string Genero {get; set;}
        public int EstoqueDisp {get; set;}
        private decimal _precoLivro;

        public Livro(string titulo, string nomeAutor, int quantidadePagina, string genero,
        int estoqueDisp, decimal precoLivro)
        {
            Titulo = titulo;
            NomeAutor = nomeAutor;
            QuantidadePagina = quantidadePagina;
            Genero = genero;
            EstoqueDisp = estoqueDisp;
            this._precoLivro = precoLivro;
        }

        public decimal GetPrecoLivro()
        {
            return _precoLivro;
        }
    }

    public class ClienteBib
    {
        private string _NomeUsuario {get; set;}
        private string _Identificacao {get; set;}
        private string _DataCompra {get; set;}

        public ClienteBib(string nomeUsuario, string identificacao, string dataCompra)
        {
            _NomeUsuario = nomeUsuario;
            _Identificacao = identificacao;
            _DataCompra = dataCompra;
        }

        public void returnUserData(Livro livro)
        {
            Console.WriteLine("+------------------------------+");
            Console.WriteLine($"Usuario: {_NomeUsuario}");
            Console.WriteLine($"Identidade: {_Identificacao}");
            Console.WriteLine($"Livro: {livro.Titulo}");
            Console.WriteLine($"Data: {_DataCompra}");
            Console.WriteLine("+------------------------------+");
        }

    }

    public class Biblioteca
    {
        List<Livro> livros = new List<Livro>(); // lista que armazena os livros


        public void adicionarDados(string tituloLivro, string nomeAutorLivro, int quantidadePagina,
        string genero, int estoqueDisp, decimal precoLivro)
        {
            Livro livro = new Livro(tituloLivro, nomeAutorLivro, quantidadePagina, genero, 
            estoqueDisp, precoLivro);

            livros.Add(livro);
        }

        public void visualizarBaseDados()
        {
            foreach (var dado in livros)
            {
                Console.WriteLine("+------------------------------+");
                Console.WriteLine($"Titulo: {dado.Titulo}");
                Console.WriteLine($"Autor: {dado.NomeAutor}");
                Console.WriteLine($"N páginas: {dado.QuantidadePagina}");
                Console.WriteLine($"Gênero: {dado.Genero}");
                Console.WriteLine($"Preço: {dado.GetPrecoLivro()}");
                Console.WriteLine($"Estoque: {dado.EstoqueDisp}");
                Console.WriteLine("+------------------------------+");
            }
        }

        public void venderLivro(string tituloLivro, string nomeCliente, string id,
        string dataCompra)
        {
            // o usuário pede um livro
            // a bib verifica se tem esse livro (pesquisa)
            // se verdade retorna que o usuario comprou o livro
            // e subtrai esse livro do estoque
            // caso contário retorna uma menssagem de indisponibilidade do produto
            
            int indexAtual = 0;

            foreach (var dado in livros)
            {
                if (dado.Titulo == tituloLivro)
                {
                    if (livros[indexAtual].EstoqueDisp > 0)
                    {
                        ClienteBib cliente = new ClienteBib(nomeCliente, id, dataCompra);
                        cliente.returnUserData(dado);
                        livros[indexAtual].EstoqueDisp--;

                        return;
                    }
                }

                indexAtual++;
            }
            
            Console.WriteLine($"Desculpe! O livro {tituloLivro} está fora de estoque.");
        }
    }

    public class MainClass
    {
        // classe MainClass onde todos os processo serão realizados
        public static void Main()
        {
            Biblioteca mainBib = new Biblioteca();

            mainBib.adicionarDados("Senhor dos Aneis", "None", 200, "Fantasia", 20, 120);
            mainBib.adicionarDados("Oshi no Ko cap 1", "Aka Akasaka & Mengo Yokoyari", 220, 
            "Drama", 100, 30);

            mainBib.venderLivro("Oshi no Ko cap 1", "Guilherme", "3242425", "31/03/2025");

            return;
        }
    }
}
