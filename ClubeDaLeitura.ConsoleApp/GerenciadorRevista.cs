using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GerenciadorRevista
    {
        Revista[] listaRevistas;
        int indiceRevista;
        Notificador notificador = new Notificador();

        public GerenciadorRevista(Revista[] revistas, int indice)
        {
            listaRevistas = revistas;
            indiceRevista = indice;
        }

        public string opcaoRevista;

        public void GerenciarRevista()
        {
            while (true)
            {
                notificador.ApresentarMensagem("Menu Revistas: ", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Adicionar Revista");

                Console.WriteLine("Digite 2 para Editar Revista");

                Console.WriteLine("Digite 3 para Excluir Revista");

                Console.WriteLine("Digite 4 para Visualizar Revistas");

                Console.WriteLine("Digite s para sair");

                opcaoRevista = Console.ReadLine();

                if (EhSair())
                {
                    break;
                }
                if (EhAdicionarRevista())
                {
                    Adicionar();
                }
                else if (EhEditarRevista())
                {
                    Visualizar();
                    Editar();
                }
                else if (EhExcluirRevista())
                {
                    Visualizar();
                    Excluir();
                }
                else if (EhVisualizarRevistas())
                {
                    Visualizar();
                }
                else if (EhOpcaoInvalida())
                {
                    notificador.ApresentarMensagem("Opção Inválida", ConsoleColor.Red);
                }
            }
        }

        public void Visualizar()
        {
            notificador.ApresentarMensagem("Revistas Cadastradas: ", ConsoleColor.Magenta);
            for (int i = 0; i < listaRevistas.Length; i++)
            {
                if (listaRevistas[i] != null)
                {
                    Console.WriteLine($"Nome: {listaRevistas[i].Nome}, Tipo de Coleção: {listaRevistas[i].TipoDeColecao}, Ano: {listaRevistas[i].AnoDaRevista}");
                }
                else
                {
                    return;
                }
            }
        }

        public void Excluir()
        {
            var indiceRevistaExcluir = BuscarIndiceRevista();

            if (indiceRevistaExcluir == null)
            {
                notificador.ApresentarMensagem("Revista não localizada!", ConsoleColor.Red);
            }
            else
            {
                listaRevistas[(int)indiceRevistaExcluir].Nome = null;
                listaRevistas[(int)indiceRevistaExcluir].TipoDeColecao = null;
                listaRevistas[(int)indiceRevistaExcluir].NumeroDaEdicao = null;
                listaRevistas[(int)indiceRevistaExcluir].AnoDaRevista = null;
            }
            notificador.ApresentarMensagem("Revista excluída!", ConsoleColor.Green);
        }

        public void Editar()
        {
            var indiceRevistaEditar = BuscarIndiceRevista();

            if (indiceRevistaEditar == null)
            {
                notificador.ApresentarMensagem("Revista não localizada!", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine("Menu de Edição de Revistas: ");

                Console.WriteLine("Digite 1 para Editar o Nome");

                Console.WriteLine("Digite 2 para Editar o Tipo de Coleção");

                Console.WriteLine("Digite 3 para Editar o Número da Edição");

                Console.WriteLine("Digite 4 para Editar o Ano");

                Console.WriteLine("Digite s para sair");

                string opcaoEditarRevista = Console.ReadLine();

                if (opcaoEditarRevista == "1")
                {
                    Console.WriteLine("Digite o novo Nome da Revista");
                    listaRevistas[(int)indiceRevistaEditar].Nome = Console.ReadLine();
                }
                else if (opcaoEditarRevista == "2")
                {
                    Console.WriteLine("Digite o novo Tipo de coleção da Revista");
                    listaRevistas[(int)indiceRevistaEditar].TipoDeColecao = Console.ReadLine();
                }
                else if (opcaoEditarRevista == "3")
                {
                    Console.WriteLine("Digite o novo Número da Edição da Revista");
                    listaRevistas[(int)indiceRevistaEditar].NumeroDaEdicao = Convert.ToInt32(Console.ReadLine());
                }
                else if (opcaoEditarRevista == "4")
                {
                    Console.WriteLine("Digite o novo Ano da Revista");
                    listaRevistas[(int)indiceRevistaEditar].AnoDaRevista = Convert.ToInt32(Console.ReadLine());

                }

                notificador.ApresentarMensagem("Revista Editada!", ConsoleColor.Green);
            }           
        }

        public void Adicionar()
        {
            Revista revista = new Revista();

            Console.WriteLine("Digite o Nome da revista: ");
            revista.Nome = Console.ReadLine();

            Console.WriteLine("Digite o tipo de Coleção da revista: ");
            revista.TipoDeColecao = Console.ReadLine();

            Console.WriteLine("Digite o número da Edição da revista: ");
            revista.NumeroDaEdicao = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Ano da revista: ");
            revista.AnoDaRevista = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Em qual caixa a revista está?");

            listaRevistas[indiceRevista] = revista;
            indiceRevista++;

            notificador.ApresentarMensagem("Revista cadastrada!", ConsoleColor.Green);
        }

        public int? BuscarIndiceRevista()
        {
            Console.WriteLine("Digite o Nome da Revista que será editada/excluída");
            string nomeRevista = Console.ReadLine();

            for (int i = 0; i < listaRevistas.Length; i++)
            {
                if (nomeRevista == listaRevistas[i]?.Nome)
                {
                    return i;
                }
            }
            return null;
        }

        public bool EhAdicionarRevista()
        {
            return opcaoRevista == "1";
        }

        public bool EhEditarRevista()
        {
            return opcaoRevista == "2";
        }

        public bool EhExcluirRevista()
        {
            return opcaoRevista == "3";
        }

        public bool EhVisualizarRevistas()
        {
            return opcaoRevista == "4";
        }

        public bool EhSair()
        {
            return opcaoRevista == "s";
        }

        public bool EhOpcaoInvalida()
        {
            if (opcaoRevista != "1" &&
                opcaoRevista != "2" &&
                opcaoRevista != "3" &&
                opcaoRevista != "4" &&
                opcaoRevista != "s")
            {
                return true;
            }
            return false;
        }        
    }
}
