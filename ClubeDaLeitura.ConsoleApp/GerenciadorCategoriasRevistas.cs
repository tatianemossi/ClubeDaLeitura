using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GerenciadorCategoriasRevistas
    {
        CategoriaRevista[] listaCategoriasRevistas;
        int indiceCategoria;
        Notificador notificador = new Notificador();

        public GerenciadorCategoriasRevistas(CategoriaRevista[] categoriaRevistas, int indice)
        {
            listaCategoriasRevistas = categoriaRevistas;
            indiceCategoria = indice;
        }


        public string opcaoCategoriaRevista;

        public void GerenciarCategoriaRevista()
        {
            while (true)
            {
                notificador.ApresentarMensagem("Menu Categorias Revistas: ", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Adicionar Categoria Revista");

                Console.WriteLine("Digite 2 para Editar Categoria Revista");

                Console.WriteLine("Digite 3 para Excluir Categoria Revista");

                Console.WriteLine("Digite 4 para Visualizar Categoria Revista");

                Console.WriteLine("Digite s para sair");

                opcaoCategoriaRevista = Console.ReadLine();

                Console.Clear();

                if (EhSair())
                {
                    break;
                }
                if (EhAdicionarCategoriaRevista())
                {
                    Adicionar();
                }
                else if (EhEditarCategoriaRevista())
                {
                    Visualizar();
                    Editar();
                }
                else if (EhExcluirCategoriaRevista())
                {
                    Visualizar();
                    Excluir();
                }
                else if (EhVisualizarCategoriasRevistas())
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
            notificador.ApresentarMensagem("Categorias de Revistas Cadastradas: ", ConsoleColor.Magenta);
            for (int i = 0; i < listaCategoriasRevistas.Length; i++)
            {
                if (listaCategoriasRevistas[i] != null)
                {
                    Console.WriteLine($"Nome: {listaCategoriasRevistas[i].Nome}, " +
                        $"Quantidade de dias do empréstimo: {listaCategoriasRevistas[i].QuantidadeDiasEmprestimo}");
                }
                else
                {
                    return;
                }
            }
        }

        public void Excluir()
        {
            var indiceCategoriaRevistaExcluir = BuscarIndiceCategoriaRevista();

            if (indiceCategoriaRevistaExcluir == null)
            {
                notificador.ApresentarMensagem("Categoria de Revista não localizada!", ConsoleColor.Red);
            }
            else
            {
                listaCategoriasRevistas[(int)indiceCategoriaRevistaExcluir].Nome = null;
                listaCategoriasRevistas[(int)indiceCategoriaRevistaExcluir].QuantidadeDiasEmprestimo = 0;
            }
            notificador.ApresentarMensagem("Categoria de Revista excluída!", ConsoleColor.Green);
        }

        public void Editar()
        {
            var indiceCategoriaEditar = BuscarIndiceCategoriaRevista();

            if (indiceCategoriaEditar == null)
            {
                notificador.ApresentarMensagem("Categoria de Revista não localizada!", ConsoleColor.Red);
            }
            else
            {
                while (true)
                {
                    notificador.ApresentarMensagem("Menu de Edição de Categoria de Revistas: ", ConsoleColor.Magenta);

                    Console.WriteLine("Digite 1 para Editar o Nome");

                    Console.WriteLine("Digite 2 para Editar o número de dias de empréstimo");

                    Console.WriteLine("Digite s para sair");

                    string opcaoEditarCategoria = Console.ReadLine();

                    Console.Clear();

                    if (opcaoEditarCategoria == "1")
                    {
                        Console.WriteLine("Digite o novo Nome da Categoria da Revista");
                        listaCategoriasRevistas[(int)indiceCategoriaEditar].Nome = Console.ReadLine();
                    }
                    else if (opcaoEditarCategoria == "2")
                    {
                        Console.WriteLine("Digite o novo número de dias de empréstimo da Categoria da Revista");
                        listaCategoriasRevistas[(int)indiceCategoriaEditar].QuantidadeDiasEmprestimo = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (opcaoEditarCategoria == "s")
                        break;

                    else if (opcaoEditarCategoria != "1" && opcaoEditarCategoria != "2" && opcaoEditarCategoria != "s")
                    {
                        notificador.ApresentarMensagem("Opção inválida", ConsoleColor.Red);
                        return;
                    }

                    notificador.ApresentarMensagem("Categoria de Revista Editada!", ConsoleColor.Green);
                }
            }
        }

        public void Adicionar()
        {
            CategoriaRevista categoriaRevista = new CategoriaRevista();

            Console.WriteLine("Digite o Nome da Categoria da revista: ");
            categoriaRevista.Nome = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de dias de empréstimo para essa categoria: ");
            categoriaRevista.QuantidadeDiasEmprestimo = Convert.ToInt32(Console.ReadLine());

            listaCategoriasRevistas[indiceCategoria] = categoriaRevista;
            indiceCategoria++;

            notificador.ApresentarMensagem("Categoria de Revista cadastrada!", ConsoleColor.Green);
        }

        public int? BuscarIndiceCategoriaRevista()
        {
            Console.WriteLine("Digite o Nome da Categoria da Revista que será editada/excluída");
            string nomeCategoriaRevista = Console.ReadLine();

            for (int i = 0; i < listaCategoriasRevistas.Length; i++)
            {
                if (nomeCategoriaRevista == listaCategoriasRevistas[i]?.Nome)
                {
                    return i;
                }
            }
            return null;
        }

        public bool EhAdicionarCategoriaRevista()
        {
            return opcaoCategoriaRevista == "1";
        }

        public bool EhEditarCategoriaRevista()
        {
            return opcaoCategoriaRevista == "2";
        }

        public bool EhExcluirCategoriaRevista()
        {
            return opcaoCategoriaRevista == "3";
        }

        public bool EhVisualizarCategoriasRevistas()
        {
            return opcaoCategoriaRevista == "4";
        }

        public bool EhSair()
        {
            return opcaoCategoriaRevista == "s";
        }

        public bool EhOpcaoInvalida()
        {
            return (opcaoCategoriaRevista != "1" &&
                opcaoCategoriaRevista != "2" &&
                opcaoCategoriaRevista != "3" &&
                opcaoCategoriaRevista != "4" &&
                opcaoCategoriaRevista != "s");
        }
    }
}
