// See https://aka.ms/new-console-template for more information
using System;

namespace DIO.Series {

    class Program {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args){

            string opcaoUser = MostrarMenu();

            while(opcaoUser.ToUpper() != "X"){
                switch(opcaoUser){
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
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Escolha uma opção válida.");
                        break;
                }
                opcaoUser = MostrarMenu();
            }

            static void ListarSeries(){
                Console.WriteLine("Listando séries.");

                var lista = repositorio.Lista();

                if(lista.Count == 0){
                    Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }

                foreach(var serie in lista){
                    Console.WriteLine("#ID {0}: - {1}", serie.retornarId(), serie.retornarTitulo());
                }
            }

            static void InserirSerie(){
                Console.WriteLine("Inserindo nova série.");

                foreach (int i in Enum.GetValues(typeof(Genero))){
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                Console.Write("Digite o genero de acordo com as opcoes acima:");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o titulo da serie:");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o ano de lançamento:");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição da serie:");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
                repositorio.Insere(novaSerie);
            }

            static void AtualizarSerie(){
                Console.WriteLine("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Genero))){
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                
                Console.Write("Digite o genero de acordo com as opcoes acima:");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o titulo da serie:");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o ano de lançamento:");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição da serie:");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
                repositorio.Atualiza(indiceSerie, atualizaSerie);
            }

            static void ExcluirSerie(){
                Console.Write("Digite o id da serie: ");

                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceSerie);
            }

            static void VisualizarSerie(){
                Console.Write("Digite o id da serie: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(indiceSerie);
                serie.MostraSerie();
            }

            string MostrarMenu(){
                Console.WriteLine();
                Console.WriteLine("Skye Séries!");
                Console.WriteLine("Escolha uma opção:");

                Console.WriteLine("1 - Listar séries");
                Console.WriteLine("2 - Inserir nova série");
                Console.WriteLine("3 - Atualizar série");
                Console.WriteLine("4 - Excluir série");
                Console.WriteLine("5 - Visualizar série");
                Console.WriteLine("C - Limpar tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUser = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUser;
            }


        }
    }
}