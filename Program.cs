using System;
using DIO.SERIES.Classes;

namespace DIO.SERIES
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOperacaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException();
                }

                opcaoUsuario = ObterOperacaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista){
                var excluido = serie.retornExcluido();
                Console.WriteLine("#ID{0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluido*" : "");
                /*
                if(!excluido){
                    Console.WriteLine("#ID{0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }*/
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Digite o ID da série");
            
            Serie novaSerie = ReceberDadosInsercao();

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar uma série");
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            if(indiceSerie < repositorio.Lista().Count){
                Serie atualizaSerie = ReceberDadosInsercao();
                atualizaSerie.Id = indiceSerie;
                repositorio.Atualiza(indiceSerie, atualizaSerie);
            }else{
                Console.WriteLine("Id da série inexistente. Favor escolher uma opção válida");
            }
        }

        private static Serie ReceberDadosInsercao()
        {
            //https:/docs.microsoft.com/pr-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            //https:/docs.microsoft.com/pr-br/dotnet/api/system.enum.getname?view=netcore-3.1
            //Enum.GetVues está pegando o nome de todos os generos
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie dadoSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            return dadoSerie;
        }

        private static void ExcluirSerie()
        {
            //Colocar uma confirmação para 
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            //Colocar uma confirmação para 
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            if(indiceSerie < repositorio.Lista().Count){
                var serie = repositorio.RetornaPorId(indiceSerie);
                Console.WriteLine(serie);
            }else{
                Console.WriteLine("Id da série inexistente. Favor escolher uma opção válida");
            }
        }

        private static string ObterOperacaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
