using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class MenuPrincipal
    {
        public string opcaoSelecionada;
        Notificador notificador = new Notificador();

        public void MostrarMenuOpcoes()
        {
            notificador.ApresentarMensagem("Clube da Leitura 1.0 ", ConsoleColor.Magenta);

            Console.WriteLine("Digite 1 para Gerenciar Revistas");

            Console.WriteLine("Digite 2 para Adicionar Amigos");

            Console.WriteLine("Digite 3 para Gerenciar Empréstimos");

            Console.WriteLine("Digite 4 para Gerenciar Caixas");

            Console.WriteLine("Digite 5 para Gerenciar Categorias de Revistas");

            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();
        }

        public bool EhGerenciarCategoriasRevistas()
        {
            return opcaoSelecionada == "5";
        }

        public bool EhGerenciarCaixas()
        {
            return opcaoSelecionada == "4";
        }

        public bool EhGerenciarEmprestimos()
        {
            return opcaoSelecionada == "3";
        }

        public bool EhGerenciarAmigos()
        {
            return opcaoSelecionada == "2";
        }

        public bool EhGerenciarRevistas()
        {
            return opcaoSelecionada == "1";
        }

        public bool EhSair()
        {
            return opcaoSelecionada == "s";
        }

        public bool EhOpcaoInvalida()
        {
            return (opcaoSelecionada != "1" &&
                opcaoSelecionada != "2" &&
                opcaoSelecionada != "3" &&
                opcaoSelecionada != "4" &&
                opcaoSelecionada != "5" &&
                opcaoSelecionada != "s");
        }
    }
}
